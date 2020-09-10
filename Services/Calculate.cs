using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AngularWebApp.Services
{
    public class Calculate
    {
        public object[] items;
        public object[] steps;
        public int mek;
        public int mgkKey;
        public double mgk;
        public double mk;
        //public int steps;
        public int fek;
        public double hk;
        public int vgkKey;
        public double vgk;
        public double sk;
        public int perc;
        public double g;
        public double bvp;
        public List<CostObjectWithPercentage> Output { get; set; }
        public int vgkperc;
        public int mgkperc;


        public Calculate(InputObject inputObject)
        {
            //dataset = data;
            items = inputObject.Items;
            mek = 0;
            mgkKey = inputObject.MGKKey;
            mgk = 0;
            mk = 0;
            steps = inputObject.Steps;
            fek = 0;
            hk = 0;
            vgkKey = inputObject.VKGKey;
            vgk = 0;
            sk = 0;
            perc = inputObject.ProfitPercentage;
            g = 0;
            bvp = 0;    
            vgkperc = 0;
            mgkperc = 0;
            calculateMEK();
        }
        private void calculateMEK()
        {
            foreach (Item item in items)
            {
                if (item.Price < 0)
                {
                    item.Price = 0;
                }

                if (item.Amount < 0)
                {
                    item.Amount = 0;
                }

                mek += item.Price * item.Amount;
            };
            calculateMGK();
        }
        private void calculateMGK()
        {
            if (mgkKey == 1)
            {
                mgk = mek * 0.2;
                mgkperc = 20;
            }
            else if (mgkKey == 2)
            {
                mgk = mek * 0.25;
                mgkperc = 25;
            }
            else if (mgkKey == 3)
            {
                mgk = mek * 0.3;
                mgkperc = 30;
            }
            else
            {
                this.mgk = 0;
            }
            calculateMK();
        }
        private void calculateMK()
        {
            mk = mek + mgk;
            calculateFEK();
        }
        private void calculateFEK()
        {
            foreach (Step step in steps)
            {
                if (step.Price < 0)
                {
                    step.Price = 0;
                }


                if (step.Time < 0)
                {
                    step.Time = 0;
                }

                fek += step.Price * step.Time;
            };
            calculateHK();
        }
        private void calculateHK()
        {
            hk = mk + fek;
            calculateVGK();
        }
        private void calculateVGK()
        {
            if (vgkKey == 1)
            {
                vgk = hk * 0.05;
                vgkperc = 5;
            }
            else if (vgkKey == 2)
            {
                vgk = hk * 0.07;
                vgkperc = 7;
            }
            else if (vgkKey == 3)
            {
                vgk = hk * 0.09;
                vgkperc = 9;
            }
            else
            {
                vgk = 0;
            }
            calculateSK();
        }
        private void calculateSK()
        {
            sk = hk + vgk;
            calculateG();
        }
        private void calculateG()
        {
            if (perc > 20)
            {
                perc = 20;
            }

            g = sk / 100 * perc;
            calculateBVP();
        }
        private void calculateBVP()
        {
            bvp = sk + g;
            createOutput();
        }
        public void createOutput()
        {
          
        }
    }
}
