﻿

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SuperTeamApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace SuperTeamApp.Data
{
    public class DummyData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                // Look for any provices.
                if (context.Foodprices != null && context.Foodprices.Any())
                {
                    return;   // DB has already been seeded
                }

                var foodprices = DummyData.GetFoodprices().ToArray();
                context.Foodprices.AddRange(foodprices);
                context.SaveChanges();


            }
        }

        public static List<Foodprice> GetFoodprices()
        {
            List<Foodprice> foodprices = new List<Foodprice>()
            {
                new Foodprice()
                {
                    FoodName="Fried spider",
                    FPrice="8 cent a bunch",
                    PictureUrl="~/image/1.jpg",
                },
              new Foodprice()
                {
                    FoodName="Fry the centipede",
                    FPrice="60 yuan a dish",
                },
                  new Foodprice()
                {
                    FoodName="Fried grasshoppers",
                    FPrice="About fifty yuan a kilo",
                },
                 new Foodprice()
                {
                    FoodName="Stir-fried golden cicada",
                    FPrice="about fourty yuan a dish",
                },
                new Foodprice()
                {
                    FoodName="Fried green silkworm  ",
                    FPrice="About fourty yuan a dish",
                },
                new Foodprice()
                {
                    FoodName="Fried scorpion ",
                    FPrice="About fourty yuan a dish",
                },
            };


            return foodprices;
        }
    }
}