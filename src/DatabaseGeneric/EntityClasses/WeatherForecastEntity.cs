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
	/// <summary>Entity class which represents the entity 'WeatherForecast'.<br/><br/></summary>
	[Serializable]
	public partial class WeatherForecastEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		private static WeatherForecastEntityStaticMetaData _staticMetaData = new WeatherForecastEntityStaticMetaData();
		private static WeatherForecastRelations _relationsFactory = new WeatherForecastRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class WeatherForecastEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public WeatherForecastEntityStaticMetaData()
			{
				SetEntityCoreInfo("WeatherForecastEntity", InheritanceHierarchyType.None, false, (int)MTech.LLBLGen.Entities.EntityType.WeatherForecastEntity, typeof(WeatherForecastEntity), typeof(WeatherForecastEntityFactory), false);
			}
		}

		/// <summary>Static ctor</summary>
		static WeatherForecastEntity()
		{
		}

		/// <summary> CTor</summary>
		public WeatherForecastEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public WeatherForecastEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this WeatherForecastEntity</param>
		public WeatherForecastEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for WeatherForecast which data should be fetched into this WeatherForecast object</param>
		public WeatherForecastEntity(System.Int32 id) : this(id, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for WeatherForecast which data should be fetched into this WeatherForecast object</param>
		/// <param name="validator">The custom validator object for this WeatherForecastEntity</param>
		public WeatherForecastEntity(System.Int32 id, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.Id = id;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected WeatherForecastEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}
		
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
		/// <param name="validator">The validator object for this WeatherForecastEntity</param>
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
		public static WeatherForecastRelations Relations { get { return _relationsFactory; } }

		/// <summary>The Date property of the Entity WeatherForecast<br/><br/></summary>
		/// <remarks>Mapped on  table field: "WeatherForecast"."Date".<br/>Table field type characteristics (type, precision, scale, length): Date, 0, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> Date
		{
			get { return (Nullable<System.DateTime>)GetValue((int)WeatherForecastFieldIndex.Date, false); }
			set	{ SetValue((int)WeatherForecastFieldIndex.Date, value); }
		}

		/// <summary>The Id property of the Entity WeatherForecast<br/><br/></summary>
		/// <remarks>Mapped on  table field: "WeatherForecast"."Id".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 Id
		{
			get { return (System.Int32)GetValue((int)WeatherForecastFieldIndex.Id, true); }
			set { SetValue((int)WeatherForecastFieldIndex.Id, value); }		}

		/// <summary>The Summary property of the Entity WeatherForecast<br/><br/></summary>
		/// <remarks>Mapped on  table field: "WeatherForecast"."Summary".<br/>Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2147483647.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Summary
		{
			get { return (System.String)GetValue((int)WeatherForecastFieldIndex.Summary, true); }
			set	{ SetValue((int)WeatherForecastFieldIndex.Summary, value); }
		}

		/// <summary>The TemperatureC property of the Entity WeatherForecast<br/><br/></summary>
		/// <remarks>Mapped on  table field: "WeatherForecast"."TemperatureC".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> TemperatureC
		{
			get { return (Nullable<System.Int32>)GetValue((int)WeatherForecastFieldIndex.TemperatureC, false); }
			set	{ SetValue((int)WeatherForecastFieldIndex.TemperatureC, value); }
		}

		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END

	}
}

namespace MTech.LLBLGen.Entities
{
	public enum WeatherForecastFieldIndex
	{
		///<summary>Date. </summary>
		Date,
		///<summary>Id. </summary>
		Id,
		///<summary>Summary. </summary>
		Summary,
		///<summary>TemperatureC. </summary>
		TemperatureC,
		/// <summary></summary>
		AmountOfFields
	}
}

namespace MTech.LLBLGen.Entities.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: WeatherForecast. </summary>
	public partial class WeatherForecastRelations: RelationFactory
	{

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticWeatherForecastRelations
	{

		/// <summary>CTor</summary>
		static StaticWeatherForecastRelations() { }
	}
}
