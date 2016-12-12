using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA
{
    class Population
    {
        public double x;
        public double y;
        public double fitness;
        public double probablity;
        public Range Range;
        public Population(double x,
         double y,
         double fitness)
        {

            this.x = x;
            this.y = y;
            this.fitness = fitness;

        }
        public Population(double x,
       double y
      )
        {

            this.x = x;
            this.y = y;

        }
        public Population(
   )
        {



        }
    }
    class Range
    {
        public Range(double Min, double Max)
        {

            this.Min = Min;
            this.Max = Max;
        }
        public double Min;
        public double Max;
    }

    class Graph
    {
       public Graph(List<double> Best, List<double> Average)
        {

            this.Best = Best;
            this.Average = Average;
        }
        public List<double> Best;
        public List<double> Average; 
    }
}
