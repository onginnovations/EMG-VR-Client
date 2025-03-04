// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: AvatarShape.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace DCL.ECSComponents {

  /// <summary>Holder for reflection information generated from AvatarShape.proto</summary>
  public static partial class AvatarShapeReflection {

    #region Descriptor
    /// <summary>File descriptor for AvatarShape.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static AvatarShapeReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChFBdmF0YXJTaGFwZS5wcm90bxIQZGVjZW50cmFsYW5kLmVjcxoTY29tbW9u",
            "L0NvbG9yMy5wcm90byK7AgoNUEJBdmF0YXJTaGFwZRIKCgJpZBgBIAEoCRIM",
            "CgRuYW1lGAIgASgJEhIKCmJvZHlfc2hhcGUYAyABKAkSGwoKc2tpbl9jb2xv",
            "chgEIAEoCzIHLkNvbG9yMxIbCgpoYWlyX2NvbG9yGAUgASgLMgcuQ29sb3Iz",
            "EhoKCWV5ZV9jb2xvchgGIAEoCzIHLkNvbG9yMxIRCgl3ZWFyYWJsZXMYByAD",
            "KAkSHQoVZXhwcmVzc2lvbl90cmlnZ2VyX2lkGAggASgJEiQKHGV4cHJlc3Np",
            "b25fdHJpZ2dlcl90aW1lc3RhbXAYCSABKAMSGgoSc3RpY2tlcl90cmlnZ2Vy",
            "X2lkGAogASgJEiEKGXN0aWNrZXJfdHJpZ2dlcl90aW1lc3RhbXAYCyABKAMS",
            "DwoHdGFsa2luZxgMIAEoCEIUqgIRRENMLkVDU0NvbXBvbmVudHNiBnByb3Rv",
            "Mw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Color3Reflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::DCL.ECSComponents.PBAvatarShape), global::DCL.ECSComponents.PBAvatarShape.Parser, new[]{ "Id", "Name", "BodyShape", "SkinColor", "HairColor", "EyeColor", "Wearables", "ExpressionTriggerId", "ExpressionTriggerTimestamp", "StickerTriggerId", "StickerTriggerTimestamp", "Talking" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class PBAvatarShape : pb::IMessage<PBAvatarShape> {
    private static readonly pb::MessageParser<PBAvatarShape> _parser = new pb::MessageParser<PBAvatarShape>(() => new PBAvatarShape());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<PBAvatarShape> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::DCL.ECSComponents.AvatarShapeReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PBAvatarShape() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PBAvatarShape(PBAvatarShape other) : this() {
      id_ = other.id_;
      name_ = other.name_;
      bodyShape_ = other.bodyShape_;
      skinColor_ = other.skinColor_ != null ? other.skinColor_.Clone() : null;
      hairColor_ = other.hairColor_ != null ? other.hairColor_.Clone() : null;
      eyeColor_ = other.eyeColor_ != null ? other.eyeColor_.Clone() : null;
      wearables_ = other.wearables_.Clone();
      expressionTriggerId_ = other.expressionTriggerId_;
      expressionTriggerTimestamp_ = other.expressionTriggerTimestamp_;
      stickerTriggerId_ = other.stickerTriggerId_;
      stickerTriggerTimestamp_ = other.stickerTriggerTimestamp_;
      talking_ = other.talking_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PBAvatarShape Clone() {
      return new PBAvatarShape(this);
    }

    /// <summary>Field number for the "id" field.</summary>
    public const int IdFieldNumber = 1;
    private string id_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Id {
      get { return id_; }
      set {
        id_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "name" field.</summary>
    public const int NameFieldNumber = 2;
    private string name_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "body_shape" field.</summary>
    public const int BodyShapeFieldNumber = 3;
    private string bodyShape_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string BodyShape {
      get { return bodyShape_; }
      set {
        bodyShape_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "skin_color" field.</summary>
    public const int SkinColorFieldNumber = 4;
    private global::Color3 skinColor_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Color3 SkinColor {
      get { return skinColor_; }
      set {
        skinColor_ = value;
      }
    }

    /// <summary>Field number for the "hair_color" field.</summary>
    public const int HairColorFieldNumber = 5;
    private global::Color3 hairColor_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Color3 HairColor {
      get { return hairColor_; }
      set {
        hairColor_ = value;
      }
    }

    /// <summary>Field number for the "eye_color" field.</summary>
    public const int EyeColorFieldNumber = 6;
    private global::Color3 eyeColor_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Color3 EyeColor {
      get { return eyeColor_; }
      set {
        eyeColor_ = value;
      }
    }

    /// <summary>Field number for the "wearables" field.</summary>
    public const int WearablesFieldNumber = 7;
    private static readonly pb::FieldCodec<string> _repeated_wearables_codec
        = pb::FieldCodec.ForString(58);
    private readonly pbc::RepeatedField<string> wearables_ = new pbc::RepeatedField<string>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<string> Wearables {
      get { return wearables_; }
    }

    /// <summary>Field number for the "expression_trigger_id" field.</summary>
    public const int ExpressionTriggerIdFieldNumber = 8;
    private string expressionTriggerId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string ExpressionTriggerId {
      get { return expressionTriggerId_; }
      set {
        expressionTriggerId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "expression_trigger_timestamp" field.</summary>
    public const int ExpressionTriggerTimestampFieldNumber = 9;
    private long expressionTriggerTimestamp_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long ExpressionTriggerTimestamp {
      get { return expressionTriggerTimestamp_; }
      set {
        expressionTriggerTimestamp_ = value;
      }
    }

    /// <summary>Field number for the "sticker_trigger_id" field.</summary>
    public const int StickerTriggerIdFieldNumber = 10;
    private string stickerTriggerId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string StickerTriggerId {
      get { return stickerTriggerId_; }
      set {
        stickerTriggerId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "sticker_trigger_timestamp" field.</summary>
    public const int StickerTriggerTimestampFieldNumber = 11;
    private long stickerTriggerTimestamp_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long StickerTriggerTimestamp {
      get { return stickerTriggerTimestamp_; }
      set {
        stickerTriggerTimestamp_ = value;
      }
    }

    /// <summary>Field number for the "talking" field.</summary>
    public const int TalkingFieldNumber = 12;
    private bool talking_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Talking {
      get { return talking_; }
      set {
        talking_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as PBAvatarShape);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(PBAvatarShape other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Id != other.Id) return false;
      if (Name != other.Name) return false;
      if (BodyShape != other.BodyShape) return false;
      if (!object.Equals(SkinColor, other.SkinColor)) return false;
      if (!object.Equals(HairColor, other.HairColor)) return false;
      if (!object.Equals(EyeColor, other.EyeColor)) return false;
      if(!wearables_.Equals(other.wearables_)) return false;
      if (ExpressionTriggerId != other.ExpressionTriggerId) return false;
      if (ExpressionTriggerTimestamp != other.ExpressionTriggerTimestamp) return false;
      if (StickerTriggerId != other.StickerTriggerId) return false;
      if (StickerTriggerTimestamp != other.StickerTriggerTimestamp) return false;
      if (Talking != other.Talking) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Id.Length != 0) hash ^= Id.GetHashCode();
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (BodyShape.Length != 0) hash ^= BodyShape.GetHashCode();
      if (skinColor_ != null) hash ^= SkinColor.GetHashCode();
      if (hairColor_ != null) hash ^= HairColor.GetHashCode();
      if (eyeColor_ != null) hash ^= EyeColor.GetHashCode();
      hash ^= wearables_.GetHashCode();
      if (ExpressionTriggerId.Length != 0) hash ^= ExpressionTriggerId.GetHashCode();
      if (ExpressionTriggerTimestamp != 0L) hash ^= ExpressionTriggerTimestamp.GetHashCode();
      if (StickerTriggerId.Length != 0) hash ^= StickerTriggerId.GetHashCode();
      if (StickerTriggerTimestamp != 0L) hash ^= StickerTriggerTimestamp.GetHashCode();
      if (Talking != false) hash ^= Talking.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Id.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Id);
      }
      if (Name.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Name);
      }
      if (BodyShape.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(BodyShape);
      }
      if (skinColor_ != null) {
        output.WriteRawTag(34);
        output.WriteMessage(SkinColor);
      }
      if (hairColor_ != null) {
        output.WriteRawTag(42);
        output.WriteMessage(HairColor);
      }
      if (eyeColor_ != null) {
        output.WriteRawTag(50);
        output.WriteMessage(EyeColor);
      }
      wearables_.WriteTo(output, _repeated_wearables_codec);
      if (ExpressionTriggerId.Length != 0) {
        output.WriteRawTag(66);
        output.WriteString(ExpressionTriggerId);
      }
      if (ExpressionTriggerTimestamp != 0L) {
        output.WriteRawTag(72);
        output.WriteInt64(ExpressionTriggerTimestamp);
      }
      if (StickerTriggerId.Length != 0) {
        output.WriteRawTag(82);
        output.WriteString(StickerTriggerId);
      }
      if (StickerTriggerTimestamp != 0L) {
        output.WriteRawTag(88);
        output.WriteInt64(StickerTriggerTimestamp);
      }
      if (Talking != false) {
        output.WriteRawTag(96);
        output.WriteBool(Talking);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Id.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Id);
      }
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (BodyShape.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(BodyShape);
      }
      if (skinColor_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(SkinColor);
      }
      if (hairColor_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(HairColor);
      }
      if (eyeColor_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(EyeColor);
      }
      size += wearables_.CalculateSize(_repeated_wearables_codec);
      if (ExpressionTriggerId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ExpressionTriggerId);
      }
      if (ExpressionTriggerTimestamp != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(ExpressionTriggerTimestamp);
      }
      if (StickerTriggerId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(StickerTriggerId);
      }
      if (StickerTriggerTimestamp != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(StickerTriggerTimestamp);
      }
      if (Talking != false) {
        size += 1 + 1;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(PBAvatarShape other) {
      if (other == null) {
        return;
      }
      if (other.Id.Length != 0) {
        Id = other.Id;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.BodyShape.Length != 0) {
        BodyShape = other.BodyShape;
      }
      if (other.skinColor_ != null) {
        if (skinColor_ == null) {
          SkinColor = new global::Color3();
        }
        SkinColor.MergeFrom(other.SkinColor);
      }
      if (other.hairColor_ != null) {
        if (hairColor_ == null) {
          HairColor = new global::Color3();
        }
        HairColor.MergeFrom(other.HairColor);
      }
      if (other.eyeColor_ != null) {
        if (eyeColor_ == null) {
          EyeColor = new global::Color3();
        }
        EyeColor.MergeFrom(other.EyeColor);
      }
      wearables_.Add(other.wearables_);
      if (other.ExpressionTriggerId.Length != 0) {
        ExpressionTriggerId = other.ExpressionTriggerId;
      }
      if (other.ExpressionTriggerTimestamp != 0L) {
        ExpressionTriggerTimestamp = other.ExpressionTriggerTimestamp;
      }
      if (other.StickerTriggerId.Length != 0) {
        StickerTriggerId = other.StickerTriggerId;
      }
      if (other.StickerTriggerTimestamp != 0L) {
        StickerTriggerTimestamp = other.StickerTriggerTimestamp;
      }
      if (other.Talking != false) {
        Talking = other.Talking;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Id = input.ReadString();
            break;
          }
          case 18: {
            Name = input.ReadString();
            break;
          }
          case 26: {
            BodyShape = input.ReadString();
            break;
          }
          case 34: {
            if (skinColor_ == null) {
              SkinColor = new global::Color3();
            }
            input.ReadMessage(SkinColor);
            break;
          }
          case 42: {
            if (hairColor_ == null) {
              HairColor = new global::Color3();
            }
            input.ReadMessage(HairColor);
            break;
          }
          case 50: {
            if (eyeColor_ == null) {
              EyeColor = new global::Color3();
            }
            input.ReadMessage(EyeColor);
            break;
          }
          case 58: {
            wearables_.AddEntriesFrom(input, _repeated_wearables_codec);
            break;
          }
          case 66: {
            ExpressionTriggerId = input.ReadString();
            break;
          }
          case 72: {
            ExpressionTriggerTimestamp = input.ReadInt64();
            break;
          }
          case 82: {
            StickerTriggerId = input.ReadString();
            break;
          }
          case 88: {
            StickerTriggerTimestamp = input.ReadInt64();
            break;
          }
          case 96: {
            Talking = input.ReadBool();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
