using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
namespace DiophantineEqu
{
    public class gene
    {
        public int[] alleles = new int[4];
        public int fitness { get; set; }
        public float likelihood { get; set; }
        public static bool operator ==(gene gn1, gene gn2)
        {
            for (int i = 0; i < 4; i++)
            {
                if (gn1.alleles[i] != gn2.alleles[i])
                    return false;
            }
            return true;
        }
        public static bool operator !=(gene gn1, gene gn2)
        {
            for (int i = 0; i < 4; i++)
            {
                if (gn1.alleles[i] != gn2.alleles[i])
                    return true;
            }
            return false;
        }
        public gene()
        {
            for (int i = 0; i < 4; i++)
                alleles[i] = Int32.MinValue;
        }
    }

    class CDiophantine
    {
        public static int MAXPOP = 25;
        static Random rand = new Random(DateTime.Now.Millisecond);

        public int ca { get; set; }
        public int cb { get; set; }
        public int cc { get; set; }
        public int cd { get; set; }
        public int result { get; set; }
        public gene[] population = new gene[MAXPOP];
        public CDiophantine(int a, int b, int c, int d, int res)
        {
            this.ca = a;
            this.cb = b;
            this.cc = c;
            this.cd = d;
            this.result = res;
        }
        public gene GetGene(int i)
        {
            return population[i];
        }
        public int Solve()
        {

            int fitness = -1;
            for (int i = 0; i < MAXPOP; i++)
            {
                population[i] = new gene();
                for (int j = 0; j < 4; j++)
                {
                    population[i].alleles[j] = rand.Next() % (result + 1);
                }
            }
            fitness = CreateFitnesses();
            if (fitness != 0)
            {
                return fitness;
            }

            int iterations = 0;
            while (fitness != 0 || iterations < 50)
            {
                GenerateLikelihoods();
                CreateNewPopulation();
                fitness = CreateFitnesses();
                if (fitness != 0)
                {
                    return fitness;
                }

                iterations++;
            }

            return -1;
        }
        public int Fitness(gene gn)
        {
            int total = ca * gn.alleles[0] + cb * gn.alleles[1] + cc * gn.alleles[2] + cd * gn.alleles[3];
            return gn.fitness = Math.Abs(total - result);
        }
        public int CreateFitnesses()
        {

            int fitness = 0;
            for (int i = 0; i < MAXPOP; i++)
            {
                fitness = Fitness(population[i]);
                if (fitness == 0)
                {
                    return i;
                }
            }
            return 0;
        }
        public float MultInv()
        {
            float sum = 0;

            for (int i = 0; i < MAXPOP; i++)
            {
                sum += 1 / ((float)population[i].fitness);
            }

            return sum;
        }
        public void GenerateLikelihoods()
        {
            float multinv = MultInv();

            float last = 0;
            for (int i = 0; i < MAXPOP; i++)
            {
                population[i].likelihood = last = last + ((1 / ((float)population[i].fitness) / multinv) * 100);
            }
        }
        public int GetIndex(float val)
        {
            float last = 0;
            for (int i = 0; i < MAXPOP; i++)
            {
                if (last <= val && val <= population[i].likelihood) return i;
                else last = population[i].likelihood;
            }

            return 4;
        }
        public gene Breed(int p1, int p2)
        {
            int crossover = rand.Next() % 3 + 1;
            int first = rand.Next() % 100;
            gene child = population[p1];

            int initial = 0, final = 3;
            if (first < 50) initial = crossover;
            else final = crossover + 1;

            for (int i = initial; i < final; i++)
            {
                child.alleles[i] = population[p2].alleles[i];
                if (rand.Next() % 101 < 5) child.alleles[i] = rand.Next() % (result + 1);
            }

            return child;
        }
        public void CreateNewPopulation()
        {
            gene[] temppop = new gene[MAXPOP];
            for (int i = 0; i < MAXPOP; i++)
            {
                int parent1 = 0, parent2 = 0, iterations = 0;
                while (parent1 == parent2 || population[parent1] == population[parent2])
                {
                    parent1 = GetIndex((float)(rand.Next() % 101));
                    parent2 = GetIndex((float)(rand.Next() % 101));
                    if (++iterations > MAXPOP * MAXPOP) break;
                }

                temppop[i] = Breed(parent1, parent2);
            }

            for (int i = 0; i < MAXPOP; i++) population[i] = temppop[i];
        }
    }
}
