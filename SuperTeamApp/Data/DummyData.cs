
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SuperTeamApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                if (context.Foodprices.Any()
                    && context.Inquiryoffices.Any())
                {
                    return;   // DB has already been seeded
                }

                var foodprices = DummyData.GetFoodprices().ToArray();
                context.Foodprices.AddRange(foodprices);
                context.SaveChanges();

                var inquiryoffices = DummyData.GetInquiryoffices(context).ToArray();
                context.Inquiryoffices.AddRange(inquiryoffices);
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
                    PictureUrl="/image/Fried_spiders.jpg",
                },
              new Foodprice()
                {
                    FoodName="Fry the centipede",
                    FPrice="60 yuan a dish",
                    PictureUrl="/image/Fry_the_centipede.jpg",
                },
                  new Foodprice()
                {
                    FoodName="Fried grasshoppers",
                    FPrice="About fifty yuan a kilo",
                    PictureUrl="/image/Fried_grasshoppers.jpg",
                },
                 new Foodprice()
                {
                    FoodName="Stir-fried golden cicada",
                    FPrice="about fourty yuan a dish",
                    PictureUrl="/image/stir_friedgolden_cicada.jpg",
                },
                new Foodprice()
                {
                    FoodName="Fried green silkworm  ",
                    FPrice="About fourty yuan a dish",
                    PictureUrl="/image/Fried_green_silkworm.jpg",
                },
                new Foodprice()
                {
                    FoodName="Fried scorpion ",
                    FPrice="About fourty yuan a dish",
                    PictureUrl="/image/Fried_scorpion.jpg",
                },
            };


            return foodprices;
        }

        public static List<Inquiryoffice> GetInquiryoffices(ApplicationDbContext context)
        {
            List<Inquiryoffice> inquiryoffices = new List<Inquiryoffice>()
            {
                new Inquiryoffice(){
                    FoodName="Fried_spiders",
                    Question="What kinds of spiders can eat?",
                    Answer="The spider, called the Thai zebra foot bird spider, belongs to the bird spider family and is about the size of a person's hand",
                },

                 new Inquiryoffice(){
                    FoodName="Fried scorpion",
                    Question="Where are the scorpion's toxins?",
                    Answer="There's a yellow dot on the needle next to the tail. It's a poison gland",
                },

                   new Inquiryoffice(){
                    FoodName="Fried cicadas",
                    Question="What medicinal value does Fried cicada monkey have?",
                    Answer="Have scanty wind cooling, rash, retreat check effect, the effect of kidney," +
                    " clear heat, detoxification, often used in the treatment of exogenous fever, cough sound " +
                    "dumb wind, sore throats, rubella SAO is urticant, red eye ,tetanus, enuresis, enteritis, pediatric" +
                    " chronic ulcerated, night cry more than disease, such as is commonly used traditional Chinese medicine" +
                    " blindly, cicada larva of the whole body is treasure, so to speak.",
                },
            };

            return inquiryoffices;
                    }


    }
}