import { getComponentName, ComponentConstructor, getComponentClassId, ComponentLike } from './Component'
import { Engine } from './Engine'
import { EventManager, EventConstructor } from './EventManager'
import { newId, log } from './helpers'

// tslint:disable:no-use-before-declare

/**
 * @public
 */
export class Entity {
  public children: Record<string, Entity> = {}
  public eventManager: EventManager | null = null
  public alive: boolean = false

  public readonly uuid: string = newId('E')
  public readonly components: Record<string, any> = {}

  // @internal
  public engine: Engine | null = null

  // @internal
  private _parent: Entity | null = null

  constructor(public name?: string) {
    // stub
  }

  /**
   * Adds or replaces a component in the entity.
   * @param component - component instance.
   */
  addComponentOrReplace<T extends object>(component: T): void {
    if (typeof component === 'function') {
      throw new Error('You passed a function or class as a component, an instance of component is expected')
    }

    if (typeof component !== 'object') {
      throw new Error(`You passed a ${typeof component}, an instance of component is expected`)
    }

    const componentName = getComponentName(component)

    if (this.components[componentName]) {
      if (this.components[componentName] === component) {
        return
      }
      this.removeComponent(this.components[componentName], false)
    }

    this.addComponent(component)
  }

  /**
   * Returns a boolean indicating if a component is present in the entity.
   * @param component - component class, instance or name
   */
  hasComponent<T = any>(component: string): boolean
  hasComponent<T>(component: ComponentConstructor<T>): boolean
  hasComponent<T extends object>(component: T): boolean
  hasComponent<T>(component: ComponentConstructor<T> | string): boolean {
    const typeOfComponent = typeof component

    if (typeOfComponent !== 'string' && typeOfComponent !== 'object' && typeOfComponent !== 'function') {
      throw new Error('Entity#has(component): component is not a class, name or instance')
    }

    if ((component as any) == null) return false

    const componentName = typeOfComponent === 'string' ? (component as string) : getComponentName(component as any)

    const storedComponent = this.components[componentName]

    if (!storedComponent) {
      return false
    }

    if (typeOfComponent === 'object') {
      return storedComponent === component
    }

    if (typeOfComponent === 'function') {
      return storedComponent instanceof (component as ComponentConstructor<T>)
    }

    return true
  }

  /**
   * Gets a component, if it doesn't exist, it throws an Error.
   * @param component - component class or name
   */
  getComponent<T = any>(component: string): T
  getComponent<T>(component: ComponentConstructor<T>): T
  getComponent<T>(component: ComponentConstructor<T> | string): T {
    const typeOfComponent = typeof component

    if (typeOfComponent !== 'string' && typeOfComponent !== 'function') {
      throw new Error('Entity#get(component): component is not a class or name')
    }

    const componentName = typeOfComponent === 'string' ? (component as string) : getComponentName(component as any)

    const storedComponent = this.components[componentName]

    if (!storedComponent) {
      throw new Error(`Can not get component "${componentName}" from entity "${this.identifier}"`)
    }

    if (typeOfComponent === 'function') {
      if (storedComponent instanceof (component as ComponentConstructor<T>)) {
        return storedComponent
      } else {
        throw new Error(`Can not get component "${componentName}" from entity "${this.identifier}" (by instance)`)
      }
    }

    return storedComponent
  }

  /**
   * Gets a component, if it doesn't exist, it returns null.
   * @param component - component class or name
   */
  getComponentOrNull<T = any>(component: string): T | null
  getComponentOrNull<T>(component: ComponentConstructor<T>): T | null
  getComponentOrNull<T>(component: ComponentConstructor<T> | string): T | null {
    const typeOfComponent = typeof component

    if (typeOfComponent !== 'string' && typeOfComponent !== 'function') {
      throw new Error('Entity#getOrNull(component): component is not a class or name')
    }

    const componentName = typeOfComponent === 'string' ? (component as string) : getComponentName(component as any)

    const storedComponent = this.components[componentName]

    if (!storedComponent) {
      return null
    }

    if (typeOfComponent === 'function') {
      if (storedComponent instanceof (component as ComponentConstructor<T>)) {
        return storedComponent
      } else {
        return null
      }
    }

    return storedComponent
  }

  /**
   * Gets a component, if it doesn't exist, it creates the component and returns it.
   * @param component - component class
   */
  getComponentOrCreate<T>(component: ComponentConstructor<T> & { new (): T }): T {
    if (typeof (component as any) !== 'function') {
      throw new Error('Entity#getOrCreate(component): component is not a class')
    }

    let ret = this.getComponentOrNull(component)

    if (!ret) {
      ret = new component()
      // Safe-guard to only add registered components to entities
      getComponentName(ret)
      this.addComponentOrReplace(ret as any)
    }

    return ret
  }

  /**
   * Adds a component. If the component already exist, it throws an Error.
   * @param component - component instance.
   */
  addComponent<T extends object>(component: T) {
    if (typeof component !== 'object') {
      throw new Error(
        'Entity#add(component): You passed a function or class as a component, an instance of component is expected'
      )
    }

    const componentName = getComponentName(component)
    const classId = getComponentClassId(component)

    if (this.components[componentName]) {
      throw new Error(`A component of type "${componentName}" is already present in entity "${this.identifier}"`)
    }

    this.components[componentName] = component

    if (this.eventManager) {
      this.eventManager.fireEvent(new ComponentAdded(this, componentName, classId))
    }
  }

  /**
   * Removes a component instance from the entity.
   * @param component - component instance to remove
   * @param triggerRemovedEvent - should this action trigger an event?
   */
  removeComponent(component: string, triggerRemovedEvent?: boolean): void
  removeComponent<T extends object>(component: T, triggerRemovedEvent?: boolean): void
  removeComponent(component: ComponentConstructor<any>, triggerRemovedEvent?: boolean): void
  removeComponent(component: object | string | Function, triggerRemovedEvent = true): void {
    const typeOfComponent = typeof component

    if (typeOfComponent !== 'string' && typeOfComponent !== 'function' && typeOfComponent !== 'object') {
      throw new Error('Entity#remove(component): component is not a class, class or name')
    }

    const componentName = typeOfComponent === 'string' ? (component as string) : getComponentName(component as any)

    const storedComponent = this.components[componentName]

    if (!storedComponent) {
      log(`Entity Warning: Trying to remove inexisting component "${componentName}" from entity "${this.identifier}"`)
      return
    }

    if (typeOfComponent === 'function') {
      if (storedComponent instanceof (component as ComponentConstructor<any>)) {
        delete this.components[componentName]

        if (triggerRemovedEvent && this.eventManager && storedComponent) {
          this.eventManager.fireEvent(new ComponentRemoved(this, componentName, storedComponent))
        }
        return
      } else {
        log(
          `Entity Warning: Trying to remove wrong (by constructor) component "${componentName}" from entity "${
            this.identifier
          }"`
        )
        return
      }
    }

    delete this.components[componentName]
    if (triggerRemovedEvent && this.eventManager && storedComponent) {
      this.eventManager.fireEvent(new ComponentRemoved(this, componentName, storedComponent))
    }
    return
  }

  /**
   * Returns true if the entity is already added to the engine.
   * Returns false if no engine was defined.
   */
  isAddedToEngine(): boolean {
    if (this.engine && this.uuid in this.engine.entities) {
      return true
    }

    return false
  }

  /**
   * Sets the parent entity
   */
  setParent(newParent: Entity) {
    let parent = !newParent && this.engine ? this.engine.rootEntity : newParent
    let currentParent = this.getParent()

    if (newParent === this) {
      throw new Error(
        `Failed to set parent for entity "${this.identifier}": An entity can't set itself as a its own parent`
      )
    }

    if (newParent === currentParent) {
      return
    }

    const circularAncestor = this.getCircularAncestor(newParent)

    if (circularAncestor) {
      throw new Error(
        `Failed to set parent for entity "${
          this.identifier
        }": Circular parent references are not allowed (See entity "${circularAncestor}")`
      )
    }

    if (currentParent) {
      delete currentParent.children[this.uuid]
    }

    if (newParent.uuid !== '0') {
      if (!newParent.isAddedToEngine() && this.isAddedToEngine()) {
        // tslint:disable-next-line:semicolon
        ;(this.engine as any).removeEntity(this)
      }
      if (newParent.isAddedToEngine() && !this.isAddedToEngine()) {
        // tslint:disable-next-line:semicolon
        ;(newParent.engine as any).addEntity(this)
      }
    }

    this._parent = parent || null
    this.registerAsChild()

    if (this.eventManager && this.engine) {
      this.eventManager.fireEvent(new ParentChanged(this, parent))
    }
  }

  /**
   * Gets the parent entity
   */
  getParent(): Entity | null {
    return this._parent
  }

  private get identifier() {
    return this.name || this.uuid
  }

  private getCircularAncestor(ent: Entity): string | null {
    const root = this.engine ? this.engine.rootEntity : null
    let e: Entity | null = ent

    while (e && e !== root) {
      const parent: Entity | null = e.getParent()
      if (parent === this) {
        return e.uuid
      }
      e = parent
    }

    return null
  }

  private registerAsChild() {
    const parent = this.getParent()

    if (this.uuid && parent) {
      parent.children[this.uuid] = this
    }
  }
}

/**
 * @public
 */
@EventConstructor()
export class ComponentRemoved {
  constructor(public entity: Entity, public componentName: string, public component: ComponentLike) {
    // stub
  }
}

/**
 * @public
 */
@EventConstructor()
export class ComponentAdded {
  constructor(public entity: Entity, public componentName: string, public classId: number | null) {
    // stub
  }
}

/**
 * @public
 */
@EventConstructor()
export class ParentChanged {
  constructor(public entity: Entity, public parent: Entity) {
    // stub
  }
}
