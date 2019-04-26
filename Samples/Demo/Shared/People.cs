namespace Demo
{
	public class Person
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Mobile { get; set; }
		public string Title { get; set; }
		public string FullName
		{
			get
			{
				var name = FirstName;
				if (null != MiddleName)
					name = $"{name} {MiddleName}";
				name = $"{name} {LastName}";

				return name;
			}
		}

		public Person(int id, string firstName, string lastName, string middleName, string email, string phone, string mobile, string title)
		{
			this.Id = id;
			this.FirstName = firstName;
			this.MiddleName = middleName;
			this.LastName = lastName;
			this.Email = email;
			this.Phone = phone;
			this.Mobile = mobile;
			this.Title = title;
		}
	}

	public static class People
	{
		const string Professor = "Professor";
		const string AssistantProfessor = "Assistant Professor";
		const string ResearchProfessor = "Research Professor";
		const string Curator = "Curator";
		const string AssociateCurator = "Associate Curator";

		public static readonly Person[] All =
		{
			new Person(3130, "Rosella", "Burks", "", "BurksR@univ.edu", "963.555.1253", "963.777.4065", Professor),
			new Person(3297, "Damien", "Avila", "", "AvilaD@univ.edu", "963.555.1352", "963.777.7914", Professor),
			new Person(3547, "Robin", "Olsen", "", "OlsenR@univ.edu", "963.555.1378", "963.777.9262", AssistantProfessor),
			new Person(1538, "Edgar", "Moises", "Estes", "MoisesE@univ.edu", "963.555.2731x3565", "963.777.8264", Professor),
			new Person(2941, "Heath", "Brian", "Pruitt", "BrianH@univ.edu", "963.555.2800", "963.777.7249", AssociateCurator),
			new Person(2401, "Elvin", "Claude", "Haney", "ClaudeE@univ.edu", "963.555.2902", "963.777.9730", Curator),
			new Person(2070, "Edmund", "Mosley", "", "MosleyE@univ.edu", "963.555.2945", "963.777.9285", AssistantProfessor),
			new Person(2561, "Antoine", "Derek", "Mccoy", "DerekA@univ.edu", "963.555.2992", "963.777.5454", Curator),
			new Person(1625, "Callie", "Hawkins", "", "HawkinsC@univ.edu", "963.555.3350x6480", "963.777.4949", Professor),
			new Person(1307, "Andrea", "Pate", "", "PateA@univ.edu", "963.555.3723", "963.777.5049", Professor),
			new Person(2342, "Liz", "Austin", "", "AustinL@univ.edu", "963.555.4305", "963.777.6143", AssistantProfessor),
			new Person(2755, "Reba", "Kendrick", "Alford", "KendrickR@univ.edu", "963.555.4618x7744", "963.777.4371", AssociateCurator),
			new Person(4150, "Angelina", "Sims", "", "SimsA@univ.edu", "963.555.5278", "963.777.4400", Professor),
			new Person(3544, "Kimberly", "Mullins", "", "MullinsK@univ.edu", "963.555.5471x1017", "963.777.9783", AssistantProfessor),
			new Person(2096, "Lloyd", "Chuck", "Haney", "ChuckL@univ.edu", "963.555.5568x2652", "963.777.9290", AssistantProfessor),
			new Person(1089, "Ladonna", "Payne", "", "PayneL@univ.edu", "963.555.5639", "963.777.6469", Professor),
			new Person(2948, "Johnathan", "Baxter", "Browning", "BaxterJ@univ.edu", "963.555.5902", "963.777.8336", ResearchProfessor),
			new Person(4539, "Gilbert", "Weiss", "", "WeissG@univ.edu", "963.555.5969", "963.777.4975", Professor),
			new Person(2811, "Florence", "Deirdre", "Barrera", "DeirdreF@univ.edu", "963.555.6319", "963.777.9654", AssociateCurator),
#if wait
			new Person(4580, "Toby", "Fernando", "Calderon", "FernandoT@univ.edu", "963.555.6469", "963.777.9864", ResearchProfessor),
			new Person(2895, "Patrica", "Garrison", "", "GarrisonP@univ.edu", "963.555.6760", "963.777.4958", AssociateCurator),
			new Person(2254, "Leila", "Effie", "Vinson", "EffieL@univ.edu", "963.555.6824", "963.777.7299", AssistantProfessor),
			new Person(2389, "Rose", "Buckley", "", "BuckleyR@univ.edu", "963.555.6855x5018", "963.777.5233", Curator),
			new Person(1699, "Kathie", "Stanton", "", "StantonK@univ.edu", "963.555.7095", "963.777.1015", Professor),
			new Person(1567, "Shannon", "Banks", "", "BanksS@univ.edu", "963.555.7198", "963.777.6979", Professor),
			new Person(3066, "Cleo", "Barnes", "", "BarnesC@univ.edu", "963.555.7463x7335", "963.777.1583", ResearchProfessor),
			new Person(2426, "Nellie", "Brady", "", "BradyN@univ.edu", "963.555.7569", "963.777.7218", Curator),
			new Person(2217, "Ruben", "Katheryn", "Holt", "KatherynR@univ.edu", "963.555.7578", "963.777.3969", AssistantProfessor),
			new Person(1968, "Dianne", "Michael", "", "MichaelD@univ.edu", "963.555.7592", "963.777.9960", AssistantProfessor),
			new Person(3012, "Adam", "Grant", "", "GrantA@univ.edu", "963.555.7775", "963.777.8115", ResearchProfessor),
			new Person(1824, "Kurtis", "Head", "", "HeadK@univ.edu", "963.555.7882", "963.777.6348", Professor),
			new Person(3929, "Jami", "Berger", "", "BergerJ@univ.edu", "963.555.8158", "963.777.5650", ResearchProfessor),
			new Person(2682, "Jaime", "Earline", "Fitzgerald", "EarlineJ@univ.edu", "963.555.8357", "963.777.4114", AssociateCurator),
			new Person(3112, "Summer", "Evelyn", "Frost", "EvelynS@univ.edu", "963.555.8895", "963.777.5730", Professor),
			new Person(2303, "Sam", "Quentin", "Hyde", "QuentinS@univ.edu", "963.555.8921", "963.777.2712", AssistantProfessor),
			new Person(3903, "Ann", "Dunlap", "", "DunlapA@univ.edu", "963.555.9067", "963.777.4290", AssistantProfessor),
			new Person(3095, "Rich", "Shields", "Pena", "ShieldsR@univ.edu", "963.555.9197", "963.777.7215", Professor),
			new Person(2383, "Winnie", "Page", "", "PageW@univ.edu", "963.555.9366", "963.777.3202", Curator),
			new Person(2146, "Ezra", "Sparks", "", "SparksE@univ.edu", "963.555.9390", "963.777.9273", AssistantProfessor),
			new Person(3958, "Elba", "Kaufman", "",@"KaufmanE@univ.edu", "963.555.9507", "963.777.3298", Professor)
#endif
		};
	}
}
