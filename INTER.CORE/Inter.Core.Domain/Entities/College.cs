namespace Inter.Core.Domain.Entities
{
    public class College
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CollegeTimeId { get; set; }

        public virtual CollegeTime Time { get; set; }

        public int EnviromentId { get; set; }

        public virtual Environment Environment { get; set; }


        public class CollegeTime
        {
            public int Id { get; set; }

            public string Time { get; set; }

            public int TimeForWeek { get; set; }

            public string Period { get; set; }
        }

    }
}
