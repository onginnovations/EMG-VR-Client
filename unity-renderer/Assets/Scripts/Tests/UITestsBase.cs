using DCL.Helpers;
using System.Collections;
using System.Collections.Generic;
using DCL;
using DCL.Controllers;
using UnityEngine;

namespace Tests
{
    public class UITestsBase : IntegrationTestSuite_Legacy
    {
        protected ParcelScene scene;
        private UIComponentsPlugin uiComponentsPlugin;
        private CoreComponentsPlugin coreComponentsPlugin;

        protected override List<GameObject> SetUp_LegacySystems()
        {
            List<GameObject> result = new List<GameObject>();
            result.AddRange(MainSceneFactory.CreatePlayerSystems());
            result.Add(MainSceneFactory.CreateEventSystem());
            return result;
        }

        protected override IEnumerator SetUp()
        {
            yield return base.SetUp();
            uiComponentsPlugin = new UIComponentsPlugin();
            coreComponentsPlugin = new CoreComponentsPlugin();
            scene = TestUtils.CreateTestScene() as ParcelScene;
            CommonScriptableObjects.sceneID.Set(scene.sceneData.id);
            DCLCharacterController.i.PauseGravity();
            TestUtils.SetCharacterPosition(new Vector3(8f, 0f, 8f));
        }

        protected override IEnumerator TearDown()
        {
            uiComponentsPlugin.Dispose();
            coreComponentsPlugin.Dispose();
            yield return base.TearDown();
        }

        protected Vector2 CalculateAlignedAnchoredPosition(Rect parentRect, Rect elementRect, string vAlign = "center", string hAlign = "center")
        {
            Vector2 result = Vector2.zero;

            switch (vAlign)
            {
                case "top":
                    result.y = -elementRect.height / 2;
                    break;
                case "bottom":
                    result.y = -(parentRect.height - elementRect.height / 2);
                    break;
                default: // center
                    result.y = -parentRect.height / 2;
                    break;
            }

            switch (hAlign)
            {
                case "left":
                    result.x = elementRect.width / 2;
                    break;
                case "right":
                    result.x = (parentRect.width - elementRect.width / 2);
                    break;
                default: // center
                    result.x = parentRect.width / 2;
                    break;
            }

            return result;
        }
    }
}