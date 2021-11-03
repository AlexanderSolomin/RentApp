using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Rent.Shared.Models;

namespace Rent.Server.Data.Configuration
{
	public class RealtyConfiguration : IEntityTypeConfiguration<Realty>
	{
		public void Configure(EntityTypeBuilder<Realty> builder)
		{
			Realty realty1 = new Realty()
			{
                        Id = Guid.Parse("eff0b478-2fe0-4bf6-903c-f45d8eb7cf16"),
				Title = "1-к. квартира, 35 м², 8/18 эт.",
				Rooms = 1,
				Description = "1-комнатные апартаменты класса люкс площадью 34,9 кв. м сдаются в аренду на длительный срок. Отделка номера выполнена из экологически чистых материалов высокого класса. Апартаменты соответствуют европейским гостиничным стандартам.",
				BuildYear = 2020,
				Area = 34.9,
				Rent = 40000,
				Storeys = 18,
				Floor = 8,
				Category = Category.RESEDENTIAL,
				ImgPath = "../Shared/Img/1.jpg",
			};

                  Realty realty2 = new Realty()
			{
                        Id = Guid.Parse("f99da879-2f09-439d-9560-6477c6b439e4"),
				Title = "4-к. квартира, 200 м², 5/6 эт.",
				Rooms = 4,
				Description = "Уникальная квартира в самом центре Санкт-Петербурга, у арки Главного штаба и Дворцовой площади. Соседи за стенкой – Государственный музей Эрмитаж. Клубный дом на 16 квартир с подземным паркингом был возведен в 2006 году строительной компанией «Возрождение СПб».",
				BuildYear = 2006,
				Area = 200,
				Rent = 300000,
				Storeys = 6,
				Floor = 5,
				Category = Category.RESEDENTIAL,
				ImgPath = "../Shared/Img/2.jpg",
			};

                  Realty realty3 = new Realty()
			{
                        Id = Guid.Parse("7ef2ade2-7b78-4be3-8c5f-85d0b3cf8e79"),
				Title = "Квартира-студия, 43 м², 2/4 эт.",
				Rooms = 1,
				Description = "Минута до дворцовой площади, минута до ст.м. Адмиралтейская, наб.р. Мойка, Литературное кафе, музеи, все прелести исторического Петербурга в которые Вы можете окунуться. В студии сделан качественный дизайнерский ремонт выполненный из экологически чистых материалов, импортная мебель и сантехника. Вход с Невского и со двора, заезд по пульту с Большой Морской свободная парковка в закрытом дворе.",
				BuildYear = 1866,
				Area = 200,
				Rent = 75000,
				Storeys = 4,
				Floor = 2,
				Category = Category.RESEDENTIAL,
				ImgPath = "../Shared/Img/3.jpg",
			};

                  Realty realty4 = new Realty()
			{
                        Id = Guid.Parse("d3b2e970-5b56-4dd1-892f-09001c397e74"),
				Title = "Склад, 2031 м²",
				Rooms = 1,
				Description = "Продуктовый склад в очень хорошем состоянии, холодильные камеры для каждого вида продукции, пандус для разгрузки, разворот для фур.",
				BuildYear = 2000,
				Area = 2031,
				Rent = 2500000,
				Storeys = 1,
				Floor = 1,
				Category = Category.COMMERCIAL,
				ImgPath = $"../Shared/Img/4.jpg",
			};

                  Realty realty5 = new Realty()
			{
                        Id = Guid.Parse("e8eaf386-265c-4f36-bfa2-b7914b454ae9"),
				Title = "Производственное помещение",
				Rooms = 1,
				Description = "Аренда сухого склада-производственного помещения от собственника без комиссии.",
				BuildYear = 2010,
				Area = 1500,
				Rent = 750000,
				Storeys = 1,
				Floor = 1,
				Category = Category.INDUSTRIAL,
				ImgPath = $"../Shared/Img/5.jpg",
			};

                  Realty realty6 = new Realty()
			{
                        Id = Guid.Parse("89140ac2-f607-425f-ac11-03e0b73c19e6"),
				Title = "Производственное помещение, 680 м²",
				Rooms = 1,
				Description = "Сдаётся встроенное производственно-складское помещение площадью 720м.кв. от собственника. Круглосуточная охрана",
				BuildYear = 1900,
				Area = 680,
				Rent = 750000,
				Storeys = 1,
				Floor = 1,
				Category = Category.INDUSTRIAL,
				ImgPath = $"../Shared/Img/6.jpg",
			};
                  
			builder.HasData(realty1);
                  builder.HasData(realty2);
			builder.HasData(realty3);
			builder.HasData(realty4);
			builder.HasData(realty5);
			builder.HasData(realty6);
		}
	}
}