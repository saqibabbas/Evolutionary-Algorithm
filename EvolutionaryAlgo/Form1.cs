using EA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace EvolutionaryAlgo
{
    public partial class Form1 : Form
    {

        List<Graph> FPS_AllGraphs = new List<Graph>();

        List<Graph> RBS_AllGraphs = new List<Graph>();
        int GraphIndex = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Run_Click(object sender, EventArgs e)
        {
            FPS_DrawGraph(FPS_AllGraphs[GraphIndex]);
            RBS_DrawGraph(RBS_AllGraphs[GraphIndex]);

            GraphIndex++;

        }

        private void BestGraph_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RunFps();
            RunRbs();
            AIS aIS = new AIS();
            aIS.start();
            chart_AIS.Series.Clear();
            chart_AIS.Series.Add("chart_AIS");

            chart_AIS.Series[0].ChartType = SeriesChartType.FastLine;
            chart_AIS.Series[0].BorderWidth = 3;

            for (int i = 0; i < 20; i++)
            {

                //if(i<10)
                chart_AIS.Series[0].Points.AddXY(i, aIS.graph[i]);

                //  tb_Final.Rows.Add(Fitenss.M
                //   Draw_chart_SRT();
            }
        }


        public void RunFps()
        {
            EAlgorithm_FPS Algo = new EAlgorithm_FPS();
            Algo.InitatePopultion();
            for (int j = 0; j <= 20; j++)
            {
                for (int i = 0; i <= 20; i++)
                {
                    Algo.MakeProbablitiesAndRanges();
                    Algo.ParentSelection();
                    Algo.CrossOver();
                    Algo.AddOfspringInPopulation();
                    Algo.FindTopFitest();
                    Algo.GetBestValue();
                    Algo.GetBestAverage();
                }
                if (j==8)
                {
                    
                }
                FPS_AllGraphs.Add(new Graph(Algo.Best, Algo.Best_average));
                Algo.OffSprings.Clear();
                //Algo.Best.Clear();
                //Algo.Best_average.Clear();
                Algo.Best = new List<double>();
                Algo.Best_average = new List<double>();
            }
            FPS_DrawGraph(FPS_AllGraphs[0]);

        }

        public void RunRbs()
        {
            EAlgorithm_RBS Algo = new EAlgorithm_RBS();
            Algo.InitatePopultion();
            for (int j = 0; j <= 20; j++)
            {
                for (int i = 0; i <= 20; i++)
                {
                    Algo.MakeProbablitiesAndRanges();
                    Algo.ParentSelection();
                    Algo.CrossOver();
                    Algo.AddOfspringInPopulation();
                    Algo.FindTopFitest();
                    Algo.GetBestValue();
                    Algo.GetBestAverage();
                }
                RBS_AllGraphs.Add(new Graph(Algo.Best, Algo.Best_average));
                Algo.Best = new List<double>();
                Algo.Best_average = new List<double>();
            }
            RBS_DrawGraph(RBS_AllGraphs[0]);
        }
        private void FPS_DrawGraph(Graph data)
        {
            BestGraph.Series.Clear();


            BestGraph.Series.Add("Best");
            BestGraph.Series.Add("Best Average");

            BestGraph.Series[0].ChartType = SeriesChartType.FastLine;
            BestGraph.Series[1].ChartType = SeriesChartType.FastLine;
            BestGraph.Series[0].Color = Color.Green;
            BestGraph.Series[0].BorderWidth = 3;

            BestGraph.Series[1].Color = Color.Red;
            BestGraph.Series[1].BorderWidth = 3;
            for (int i = 0; i < data.Best.Count; i++)
            {
                BestGraph.Series[0].Points.AddXY(i, data.Best[i]);
            }

            for (int i = 0; i < data.Average.Count; i++)
            {

                BestGraph.Series[1].Points.AddXY(i, data.Average[i]);


            }
        }

       
        private void RBS_DrawGraph(Graph data)
        {
            Rbs_graph.Series.Clear();


            Rbs_graph.Series.Add("Best");
            Rbs_graph.Series.Add("Best Average");

            Rbs_graph.Series[0].ChartType = SeriesChartType.FastLine;
            Rbs_graph.Series[1].ChartType = SeriesChartType.FastLine;
            Rbs_graph.Series[0].Color = Color.Green;
            Rbs_graph.Series[0].BorderWidth = 3;

            Rbs_graph.Series[1].Color = Color.Red;
            Rbs_graph.Series[1].BorderWidth = 3;
            for (int i = 0; i < data.Best.Count; i++)
            {
                Rbs_graph.Series[0].Points.AddXY(i, data.Best[i]);
            }

            for (int i = 0; i < data.Average.Count; i++)
            {

                Rbs_graph.Series[1].Points.AddXY(i, data.Average[i]);


            }
        }


        private void btn_last_Click(object sender, EventArgs e)
        {
            FPS_DrawGraph(FPS_AllGraphs[20]);
            RBS_DrawGraph(RBS_AllGraphs[20]);

        }


        ///////////



    }

    class EAlgorithm_FPS
    {
        public List<Population> Population = new List<Population>();
        public List<Population> OffSprings = new List<Population>();

        public List<double> Best = new List<double>();
        public List<double> Best_average = new List<double>();

        Random randx = new Random();
        Random randy = new Random();
        public void InitatePopultion()
        {
            for (int i = 0; i < 50; i++)
            {
                double x = randx.NextDouble() * (2 - (-2)) + (-2);
                double y = randy.NextDouble() * (5 - (-5)) + (-5);
                double fitness = x * x + y * y;
                Population.Add(new Population(x, y, fitness));
            }

        }
        public void MakeProbablitiesAndRanges()
        {
            double FitnessSum = Population.Select(m => m.fitness).ToList().Sum();
            double min = 0;
            double max = 0;
            foreach (var item in Population)
            {
                double fitness = item.fitness;
                item.probablity = fitness / FitnessSum;
                max = min + item.probablity;
                if (item.probablity == 0.0)
                {

                }
                if (min != 0)
                {
                    min += 0.0000000000000000001;
                }
                item.Range = new Range(min, max);
                if (item.Range == null)
                {

                }
                min = max;
            }
        }
        public void ParentSelection()
        {
            for (int i = 0; i <= 29; i++)
            {
                double no = randx.NextDouble();
                //if (no > 0.997)
                //{
                //    i--;

                //    continue;
                //}

                int index = Population.FindIndex(m => m.Range.Min <= no && m.Range.Max >= no);

                //if (no < 0.2)
                //{
                //    OffSprings.Add(new Population(Population[index].x + no, Population[index].y + no));
                //}
                //else
                //{
                OffSprings.Add(new Population(Population[index].x, Population[index].y));

                //}
            }
        }
        public void CrossOver()
        {
            for (int i = 0; i <= 14; i++)
            {
                double tempy = OffSprings[i].y;
                OffSprings[i].y = OffSprings[i++].y;
                OffSprings[i++].y = tempy;
            }
        }
        public void AddOfspringInPopulation()
        {
            for (int i = 0; i <= 29; i++)
            {
                double x = OffSprings[i].x; 
                double y = OffSprings[i].y;
                double x1 = randx.NextDouble();
                double y1 = randy.NextDouble();
                if (x1 > 0.2)
                {
                    //x = (randx.NextDouble() * (0.05 - (-0.05)) + (-0.05)) + x;
                    x = (randx.NextDouble() * (0.05 - (-0.05)) + (-0.05)) ;


                }
                if (y1 > 0.2)
                {
                    //y = (randy.NextDouble() * (0.05 - (-0.05)) + (-0.05)) + y;
                    y = (randy.NextDouble() * (0.05 - (-0.05)) + (-0.05)) ;

                }
                double fitness = x * x + y * y;
                if (fitness>=30)
                {
                    
                }
                Population.Add(new Population(x, y, fitness));
            }

        }
        public void FindTopFitest()
        {

            var fitest = Population.OrderByDescending(m => m.fitness).ToList().GetRange(0, 50);
            Population.Clear();
            Population = fitest;
            //MakeProbablitiesAndRanges( Population.Select(m => m.fitness).ToList().Sum());
        }

        public void GetBestValue()
        {
            Best.Add(Population.Select(a => a.fitness).Max());
        }
        public void GetBestAverage()
        {
            Best_average.Add(Population.Select(a => a.fitness).Average());
        }


    }
    class EAlgorithm_RBS
    {
        public List<Population> Population = new List<Population>();
        public List<Population> OffSprings = new List<Population>();

        public List<double> Best = new List<double>();
        public List<double> Best_average = new List<double>();

        Random randx = new Random();
        Random randy = new Random();
        public void InitatePopultion()
        {
            for (int i = 0; i < 50; i++)
            {
                double x = randx.NextDouble() * (2 - (-2)) + (-2);
                double y = randy.NextDouble() * (5 - (-5)) + (-5);
                double fitness = x * x + y * y;
                Population.Add(new Population(x, y, fitness));
            }

        }
        public void MakeProbablitiesAndRanges()
        {
            double FitnessSum = Population.Select(m => m.fitness).ToList().Sum();
            double min = 0;
            double max = 0;
            foreach (var item in Population)
            {
                double fitness = item.fitness;
                item.probablity = fitness / FitnessSum;
                max = min + item.probablity;
                if (item.probablity == 0.0)
                {

                }
                if (min != 0)
                {
                    min += 0.0000000000000000001;
                }
                item.Range = new Range(min, max);
                if (item.Range == null)
                {

                }
                min = max;
            }
        }
        public void ParentSelection()
        {
            for (int i = 0; i <= 29; i++)
            {
                double no = randx.NextDouble();
                //if (no > 0.997)
                //{
                //    i--;

                //    continue;
                //}

                int index = Population.FindIndex(m => m.Range.Min <= no && m.Range.Max >= no);

                //if (no < 0.2)
                //{
                //    OffSprings.Add(new Population(Population[index].x + no, Population[index].y + no));
                //}
                //else
                //{
                OffSprings.Add(new Population(Population[index].x, Population[index].y));

                //}
            }
        }
        public void CrossOver()
        {
            for (int i = 0; i <= 14; i++)
            {
                double tempy = OffSprings[i].y;
                OffSprings[i].y = OffSprings[i++].y;
                OffSprings[i++].y = tempy;
            }
        }
        public void AddOfspringInPopulation()
        {
            for (int i = 0; i <= 29; i++)
            {
                double x = OffSprings[i].x;
                double y = OffSprings[i].y;
                double x1 = randx.NextDouble();
                double y1 = randy.NextDouble();
                if (x1 > 0.2)
                {
                    x = (randx.NextDouble() * (0.05 - (-0.05)) + (-0.05)) + x;
                }
                if (y1 > 0.2)
                {
                    y = (randy.NextDouble() * (0.05 - (-0.05)) + (-0.05)) + y;
                }
                double fitness = x * x + y * y;

                Population.Add(new Population(x, y, fitness));
            }

        }
        public void FindTopFitest()
        {

            var fitest = Population.OrderByDescending(m => m.x).ToList().GetRange(0, 50);
            Population.Clear();
            Population = fitest;
            //MakeProbablitiesAndRanges( Population.Select(m => m.fitness).ToList().Sum());
        }

        public void GetBestValue()
        {
            Best.Add(Population.Select(a => a.fitness).Max());
        }
        public void GetBestAverage()
        {
            Best_average.Add(Population.Select(a => a.fitness).Average());
        }


    }

    class AIS
    {
        Random rnd = new Random();
        List<double> value_x = new List<double>();
        List<double> value_y = new List<double>();
        List<double> value_x_random = new List<double>();
        List<double> value_y_random = new List<double>();
        List<double> S = new List<double>();
        public List<double> F = new List<double>();
        List<double> R = new List<double>();
        List<double> Probability = new List<double>();
        List<double> Mutation_random = new List<double>();
        public List<double> graph = new List<double>();

        void generate_randomNo()
        {

            for (int i = 0; i < 10; i++)
            {
                value_x.Add(-2 + rnd.NextDouble() * (2 + 2));
                value_y.Add(-5 + rnd.NextDouble() * (5 + 5));
            }

        }

        double function(double x, double y)
        {
            double ans;
            ans = (x * x) + (y * y);
            return ans;
        }

        void getFitness()
        {
            for (int i = 0; i < 10; i++)
            {
                F.Add(function(value_x[i], value_y[i]));
            }

        }

        void select_S()
        {
            F.Sort();
            F.Reverse();
            for (int i = 0; i < 5; i++)
            {
                S.Add(F[i]);
            }
        }

        void Mutation()
        {
            for (int i = 0; i < 5; i++)
            {
                var value = (-0.05 + rnd.NextDouble() * (0.05 + 0.05)) * (1 / S[i]);
                Mutation_random.Add(value);
            }
            for (int i = 0; i < 5; i++)
            {
                S[i] = S[i] + Mutation_random[i];
                F.Add(S[i]);
            }

        }

        void Exploration()
        {
            for (int i = 0; i < 3; i++)
            {
                value_x_random.Add(-2 + rnd.NextDouble() * (2 + 2));
                value_y_random.Add(-5 + rnd.NextDouble() * (5 + 5));
                F.Add(function(value_x_random[i], value_y_random[i]));
            }

        }

        void select_best10()
        {
            F.Sort();
            F.Reverse();
            List<double> temp = new List<double>();
            for (int i = 0; i < 10; i++)
            {
                temp.Add(F[i]);
            }
            F.Clear();
            F = temp;

        }
        public void start()
        {
            generate_randomNo();
            getFitness();
            for (int i = 0; i < 20; i++)
            {
                select_S();
                Mutation();
                Exploration();
                select_best10();
                var t = F.Sum() / 10;
                graph.Add(t);
            }
            var temp = F;
        }

    }

}
