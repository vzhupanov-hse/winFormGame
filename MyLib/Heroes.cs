namespace MyLib
{
    public class Heroes
    {
        string name;
        double damage;
        double reload;
        double life;
        double shoot;
        double headshot;

        public string Name
        {
            get => name; set
            {
                name = value;
            }
        }

        public double Shoot { get => shoot; set
            {
                shoot = value;
            }
        }

        public double HeadShot { get => headshot; set
            {
                    headshot = value;
            }
        }

        public double Reload { get => reload; set
            {
                    reload = value;
            }
        }

        public double Damage { get => damage; set
            {
                    damage = value;
            }
        }

        public double Life {  get => life; set
            {
                    life = value;
            }
        }
    }
}
