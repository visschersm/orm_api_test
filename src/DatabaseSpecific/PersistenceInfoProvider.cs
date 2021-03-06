﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro v5.7.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace MTech.LLBLGen.Entities.DatabaseSpecific
{
	/// <summary>Singleton implementation of the PersistenceInfoProvider. This class is the singleton wrapper through which the actual instance is retrieved.</summary>
	internal static class PersistenceInfoProviderSingleton
	{
		private static readonly IPersistenceInfoProvider _providerInstance = new PersistenceInfoProviderCore();

		/// <summary>Dummy static constructor to make sure threadsafe initialization is performed.</summary>
		static PersistenceInfoProviderSingleton() {	}

		/// <summary>Gets the singleton instance of the PersistenceInfoProviderCore</summary>
		/// <returns>Instance of the PersistenceInfoProvider.</returns>
		public static IPersistenceInfoProvider GetInstance() { return _providerInstance; }
	}

	/// <summary>Actual implementation of the PersistenceInfoProvider. Used by singleton wrapper.</summary>
	internal class PersistenceInfoProviderCore : PersistenceInfoProviderBase
	{
		/// <summary>Initializes a new instance of the <see cref="PersistenceInfoProviderCore"/> class.</summary>
		internal PersistenceInfoProviderCore()
		{
			Init();
		}

		/// <summary>Method which initializes the internal datastores with the structure of hierarchical types.</summary>
		private void Init()
		{
			this.InitClass();
			InitAnimalEntityMappings();
			InitCowEntityMappings();
			InitDogEntityMappings();
			InitTodoItemEntityMappings();
			InitWeatherForecastEntityMappings();
		}

		/// <summary>Inits AnimalEntity's mappings</summary>
		private void InitAnimalEntityMappings()
		{
			this.AddElementMapping("AnimalEntity", @"AnimalFarm", @"dbo", "Animal", 3, 0);
			this.AddElementFieldMapping("AnimalEntity", "Id", "Id", false, "Int", 0, 10, 0, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("AnimalEntity", "Name", "Name", true, "NVarChar", 2147483647, 0, 0, false, "", null, typeof(System.String), 1);
			this.AddElementFieldMapping("AnimalEntity", "Type", "Type", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 2);
		}

		/// <summary>Inits CowEntity's mappings</summary>
		private void InitCowEntityMappings()
		{
			this.AddElementMapping("CowEntity", @"AnimalFarm", @"dbo", "Cow", 1, 0);
			this.AddElementFieldMapping("CowEntity", "Id", "Id", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 0);
		}

		/// <summary>Inits DogEntity's mappings</summary>
		private void InitDogEntityMappings()
		{
			this.AddElementMapping("DogEntity", @"AnimalFarm", @"dbo", "Dog", 1, 0);
			this.AddElementFieldMapping("DogEntity", "Id", "Id", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 0);
		}

		/// <summary>Inits TodoItemEntity's mappings</summary>
		private void InitTodoItemEntityMappings()
		{
			this.AddElementMapping("TodoItemEntity", @"TodoList", @"dbo", "TodoItem", 2, 0);
			this.AddElementFieldMapping("TodoItemEntity", "Id", "Id", false, "Int", 0, 10, 0, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("TodoItemEntity", "Title", "Title", false, "VarChar", 128, 0, 0, false, "", null, typeof(System.String), 1);
		}

		/// <summary>Inits WeatherForecastEntity's mappings</summary>
		private void InitWeatherForecastEntityMappings()
		{
			this.AddElementMapping("WeatherForecastEntity", @"WeatherForecast", @"dbo", "WeatherForecast", 4, 0);
			this.AddElementFieldMapping("WeatherForecastEntity", "Date", "Date", true, "Date", 0, 0, 0, false, "", null, typeof(System.DateTime), 0);
			this.AddElementFieldMapping("WeatherForecastEntity", "Id", "Id", false, "Int", 0, 10, 0, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 1);
			this.AddElementFieldMapping("WeatherForecastEntity", "Summary", "Summary", true, "VarChar", 2147483647, 0, 0, false, "", null, typeof(System.String), 2);
			this.AddElementFieldMapping("WeatherForecastEntity", "TemperatureC", "TemperatureC", true, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 3);
		}

	}
}
