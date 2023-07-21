/*
 * 
>>Sofa<<312.23!3
>>TV<<300!5
>Invalid<<!5
Purchase

>>Chair<<412.23!3
>>Sofa<<500!5
>>Recliner<<<<!5
>>Bench<<230!10
>>>>>>Rocking chair<<!5
>>Bed<<700!5
Purchase

 */


using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _1._furniture
{
    internal class Program
    { 
        public class Furniture 
    {
            public string Name { get; set; }
            public decimal Cost { get; set; }
            public int Qty { get; set; }
            public decimal Total () { return Cost*Qty; }
    }
            
        static void Main(string[] args)
        {
            List<Furniture> furnitures = new List<Furniture>();
            string pattern = @">>([A-z]+)<<(\d+\.\d+|\d+)!(\d+)";

            

            string cmd ;

            while ((cmd = Console.ReadLine()) != "Purchase")
            {
                Regex regex = new Regex(pattern);
                MatchCollection match = regex.Matches(cmd);

                Furniture furniture = new Furniture();
                foreach (Match m in match) 
                
                {
                
                    furniture.Name = m.Groups[1].Value;
                    furniture.Cost = decimal.Parse(m.Groups[2].Value);
                    furniture.Qty = int.Parse(m.Groups[3].Value);
                    
                    furnitures.Add(furniture);
                }
            }

            decimal sum = 0;
            Console.WriteLine("Bought furniture:");
            foreach (Furniture furniture in furnitures)
            {
                Console.WriteLine($"{furniture.Name}");
                sum += furniture.Total();

            }
            Console.WriteLine($"Total money spend: {sum:f2}");
        }
    }
}
