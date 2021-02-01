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
using MTech.LLBLGen.Entities.HelperClasses;
using MTech.LLBLGen.Entities.FactoryClasses;
using MTech.LLBLGen.Entities.RelationClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace MTech.LLBLGen.Entities.EntityClasses
{
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	/// <summary>Entity class which represents the entity 'Dog'.<br/><br/></summary>
	[Serializable]
	public partial class DogEntity : AnimalEntity
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		private static DogEntityStaticMetaData _staticMetaData = new DogEntityStaticMetaData();
		private static DogRelations _relationsFactory = new DogRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public new static partial class MemberNames
		{
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class DogEntityStaticMetaData : AnimalEntityStaticMetaData
		{
			public DogEntityStaticMetaData()
			{
				SetEntityCoreInfo("DogEntity", InheritanceHierarchyType.TargetPerEntity, true, (int)MTech.LLBLGen.Entities.EntityType.DogEntity, typeof(DogEntity), typeof(DogEntityFactory), false);
			}
		}

		/// <summary>Static ctor</summary>
		static DogEntity()
		{
		}

		/// <summary> CTor</summary>
		public DogEntity()
		{
			InitClassEmpty();
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public DogEntity(IEntityFields2 fields) : base(fields)
		{
			InitClassEmpty();
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this DogEntity</param>
		public DogEntity(IValidator validator) : base(validator)
		{
			InitClassEmpty();
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for Dog which data should be fetched into this Dog object</param>
		public DogEntity(System.Int32 id) : base(id)
		{
			InitClassEmpty();
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for Dog which data should be fetched into this Dog object</param>
		/// <param name="validator">The custom validator object for this DogEntity</param>
		public DogEntity(System.Int32 id, IValidator validator) : base(id, validator)
		{
			InitClassEmpty();
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected DogEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Gets a predicateexpression which filters on this entity. Only useful in entity fetches</summary>
		/// <param name="negate">Optional flag to produce a NOT filter, (true), or a normal filter (false, default). </param>
		/// <returns>ready to use predicateexpression</returns>
		public new static IPredicateExpression GetEntityTypeFilter(bool negate=false) { return ModelInfoProviderSingleton.GetInstance().GetEntityTypeFilter("DogEntity", negate); }
		
		/// <inheritdoc/>
		protected override EntityStaticMetaDataBase GetEntityStaticMetaData() {	return _staticMetaData; }

		/// <summary>Initializes the class members</summary>
		private void InitClassMembers()
		{

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Initializes the class with empty data, as if it is a new Entity.</summary>
		private void InitClassEmpty()
		{
			InitClassMembers();
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassEmpty
			// __LLBLGENPRO_USER_CODE_REGION_END

		}

		/// <summary>The relations object holding all relations of this entity with other entity classes.</summary>
		public new static DogRelations Relations { get { return _relationsFactory; } }

		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END

	}
}

namespace MTech.LLBLGen.Entities
{
	public enum DogFieldIndex
	{
		///<summary>Id. Inherited from Animal</summary>
		Id_Animal,
		///<summary>Name. Inherited from Animal</summary>
		Name,
		///<summary>Type. Inherited from Animal</summary>
		Type,
		///<summary>Id. </summary>
		Id,
		/// <summary></summary>
		AmountOfFields
	}
}

namespace MTech.LLBLGen.Entities.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: Dog. </summary>
	public partial class DogRelations: AnimalRelations
	{

		/// <summary>Returns a new IEntityRelation object, between DogEntity and AnimalEntity over the 1:1 relation they have, which is used to build a target per entity hierarchy</summary>
		internal IEntityRelation RelationToSuperTypeAnimalEntity
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateHierarchyRelation(false, new[] { AnimalFields.Id, DogFields.Id }); }
		}

		/// <inheritdoc/>
		public override IEntityRelation GetSubTypeRelation(string subTypeEntityName)
		{
			return null;
		}
		
		/// <inheritdoc/>
		public override IEntityRelation GetSuperTypeRelation()	{ return this.RelationToSuperTypeAnimalEntity; }

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticDogRelations
	{

		/// <summary>CTor</summary>
		static StaticDogRelations() { }
	}
}