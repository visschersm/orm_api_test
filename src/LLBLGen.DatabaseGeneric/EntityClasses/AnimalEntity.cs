﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro 5.7.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using MTech.Entities.HelperClasses;
using MTech.Entities.FactoryClasses;
using MTech.Entities.RelationClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace MTech.Entities.EntityClasses
{
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	/// <summary>Entity class which represents the entity 'Animal'.<br/><br/></summary>
	[Serializable]
	public partial class AnimalEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		private static AnimalEntityStaticMetaData _staticMetaData = new AnimalEntityStaticMetaData();
		private static AnimalRelations _relationsFactory = new AnimalRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class AnimalEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public AnimalEntityStaticMetaData()
			{
				SetEntityCoreInfo("AnimalEntity", InheritanceHierarchyType.TargetPerEntity, false, (int)MTech.Entities.EntityType.AnimalEntity, typeof(AnimalEntity), typeof(AnimalEntityFactory), false);
			}
		}

		/// <summary>Static ctor</summary>
		static AnimalEntity()
		{
		}

		/// <summary> CTor</summary>
		public AnimalEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public AnimalEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this AnimalEntity</param>
		public AnimalEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for Animal which data should be fetched into this Animal object</param>
		public AnimalEntity(System.Int32 id) : this(id, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for Animal which data should be fetched into this Animal object</param>
		/// <param name="validator">The custom validator object for this AnimalEntity</param>
		public AnimalEntity(System.Int32 id, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.Id = id;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected AnimalEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Gets a predicateexpression which filters on this entity. Only useful in entity fetches</summary>
		/// <param name="negate">Optional flag to produce a NOT filter, (true), or a normal filter (false, default). </param>
		/// <returns>ready to use predicateexpression</returns>
		public  static IPredicateExpression GetEntityTypeFilter(bool negate=false) { return ModelInfoProviderSingleton.GetInstance().GetEntityTypeFilter("AnimalEntity", negate); }
		
		/// <inheritdoc/>
		protected override EntityStaticMetaDataBase GetEntityStaticMetaData() {	return _staticMetaData; }

		/// <summary>Initializes the class members</summary>
		private void InitClassMembers()
		{
			PerformDependencyInjection();
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnInitClassMembersComplete();
		}

		/// <summary>Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this AnimalEntity</param>
		/// <param name="fields">Fields of this entity</param>
		private void InitClassEmpty(IValidator validator, IEntityFields2 fields)
		{
			OnInitializing();
			this.Fields = fields ?? CreateFields();
			this.Validator = validator;
			InitClassMembers();
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassEmpty
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		/// <summary>The relations object holding all relations of this entity with other entity classes.</summary>
		public static AnimalRelations Relations { get { return _relationsFactory; } }

		/// <summary>The Id property of the Entity Animal<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Animal"."Id".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 Id
		{
			get { return (System.Int32)GetValue((int)AnimalFieldIndex.Id, true); }
			set { SetValue((int)AnimalFieldIndex.Id, value); }		}

		/// <summary>The Name property of the Entity Animal<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Animal"."Name".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2147483647.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)AnimalFieldIndex.Name, true); }
			set	{ SetValue((int)AnimalFieldIndex.Name, value); }
		}

		/// <summary>The Type property of the Entity Animal<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Animal"."Type".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 Type
		{
			get { return (System.Int32)GetValue((int)AnimalFieldIndex.Type, true); }
			set	{ SetValue((int)AnimalFieldIndex.Type, value); }
		}

		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END

	}
}

namespace MTech.Entities
{
	public enum AnimalFieldIndex
	{
		///<summary>Id. </summary>
		Id,
		///<summary>Name. </summary>
		Name,
		///<summary>Type. </summary>
		Type,
		/// <summary></summary>
		AmountOfFields
	}
}

namespace MTech.Entities.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: Animal. </summary>
	public partial class AnimalRelations: RelationFactory
	{

		/// <summary>Returns a new IEntityRelation object, between AnimalEntity and CowEntity over the 1:1 relation they have, which is used to build a target per entity hierarchy</summary>		
		internal IEntityRelation RelationToSubTypeCowEntity
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateHierarchyRelation(true, new[] { AnimalFields.Id, CowFields.Id }); }
		}

		/// <summary>Returns a new IEntityRelation object, between AnimalEntity and DogEntity over the 1:1 relation they have, which is used to build a target per entity hierarchy</summary>		
		internal IEntityRelation RelationToSubTypeDogEntity
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateHierarchyRelation(true, new[] { AnimalFields.Id, DogFields.Id }); }
		}

		/// <inheritdoc/>
		public override IEntityRelation GetSubTypeRelation(string subTypeEntityName)
		{
			switch(subTypeEntityName)
			{
				case "CowEntity":
					return this.RelationToSubTypeCowEntity;
				case "DogEntity":
					return this.RelationToSubTypeDogEntity;
				default:
					return null;
			}
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticAnimalRelations
	{

		/// <summary>CTor</summary>
		static StaticAnimalRelations() { }
	}
}
