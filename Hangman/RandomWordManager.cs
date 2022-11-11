using System;
using System.Drawing;

namespace Hangman
{
  /// <summary>
  /// Manages choosing a random word for playing hangman
  /// </summary>
  public class RandomWordManager
  {
    private Random RandomPick;
    private Random RandomCategory;
    private int category = 0;
    
    private string[] categories = new string[]
    {
      "Objects", "Food", "Herbs & Spices", "Animals", "Birds", "Insects", "Fish", "Sea Creatures", "Sports", 
      "Instruments", "Professions", "Vehicles", "Geography", "Colours", "Chemical Elements", "Weather", 
      "Tools", "Cities", "Famous People", "Composers", "Countries", "Clothes", "The Universe", 
      "Around The Home", "Computing", "Time", "Building Materials", "Nuts"
    };
    
    private string[][] words = new string[][]
    {
      new string[] // objects
      {
        "anchor", "battery", "binoculars", "bolt", "book", "building", "camera", "cassette", "clock",
        "dictionary", "envelope", "furnace", "gate", "hinge", "hotel", "key", "lamp", "lock", "magnet",
        "newspaper", "picture", "radio", "telephone", "towel"
      },
      
      new string[] // Food
      {
        "apple", "anchovy", "apricot", "asparagus", "bacon", "banana", "bean", "beef", "beetroot", "blackberry", 
        "blueberry", "bread", "broccoli", "butter", "cabbage", "cantaloupe", "carrot", "cauliflower", "celery", "cheese", 
        "cherry", "chicken", "chocolate", "coconut", "corn", "courgette", "cranberry", "cream", "croissant", "cucumber", 
        "currant", "damson", "date", "donut", "egg", "fig", "garlic", "grape", "grapefruit", "Guava",  "honey", "Jujube", 
        "kale", "kiwi", "kumquat", "leek", "lemon", "lettuce", "lime", "lychee", "mandarin", "mango", "melon", "milk", 
        "nectarine", "noodle", "okra", "onion", "orange", "papaya", "papaw", "pasta",
        "pea", "peach", "pear", "pepper", "persimmon", "pineapple", "pizza", "plum", "pomegranate", "pork",
        "potato", "prune", "pumpkin", "radish", "raspberry", "salt", "sandwich", "sausage", "spaghetti", "spinach",
        "squash", "strawberry", "sugar", "tangerine", "Tomato", "Tuna", "Turkey", "turnip", "watermelon", "Yoghurt"
      },
      
      new string[] // Herbs & Spices
      {
        "Anise", "Arrowroot", "basil", "bay", "Caraway", "cardamon", "cayenne", "Chervil", "Chives", "chilli", "Cilantro",
        "Cinnamon", "cloves", "coriander", "cumin", "curry", "Dill", "Fennel", "garam", "Garlic", "ginger", "Ginger",
        "Horseradish", "Juniper", "Mace", "Marjoram", "Mint", "Mustard", "Nutmeg", "Oregano", "Paprika", "Parsley",
        "Pepper", "Rosemary", "Saffron", "Sage", "Tarragon", "Thyme", "Turmeric", "Vanilla"
      },
      
      new string[] // Animals
      {
        "aardvark", "adder", "alligator", "badger", "bat", "bear", "beaver", "bird", "bison", "buffalo",
        "butterfly", "camel", "cariboo", "cat", "cheetah", "chicken", "chimpanzee", "chipmunk", "cow", "crocodile",
        "deer", "dog", "donkey", "elephant", "fox", "frog", "giraffe", "goat", "gorilla", "grasshopper", "hamster", 
        "hippopotamus", "horse", "kangaroo", "koala", "iguana", "lamb", "leopard", "lion", "lizard", "llama", 
        "monkey", "moose", "mouse", "ocelot", "orangutan", "otter", "panda", "panther", "pig", "porcupine",
        "rabbit", "raccoon", "rat", "reindeer", "rhinoceros", "rooster", "salamander", "scorpion", "sheep",
        "snail", "snake", "spider", "squirrel", "stoat", "tiger", "toad", "tortoise", "turkey", "turtle", "walrus",
        "weasel", "wolf", "worm", "zebra"
      },
      
      new string[] // Birds
      {
        "Auk", "Avocet", "Bittern", "Blackbird", "Blackcap", "Brambling", "Budgie", "Bullfinch", "Buzzard", 
        "Chaffinch", "Chiffchaff", "Chough", "Coot", "Cormorant", "Corncrake", "Crossbill", "Crow", "Cuckoo", 
        "Curlew", "Dipper", "Dove", "Duck", "Dunlin", "Dunnock", "Dove", "Eagle", "Egret", "Eider", "Falcon",
        "Fieldfare", "Firecrest", "Fulmar", "Gadwall", "Gannet", "Garganey", "Godwit", "Goldcrest", "Goldeneye", 
        "Goldfinch", "Goosander", "Goose", "Goshawk", "Grebe", "Greenfinch", "Greenshank", "Grouse", "Guillemot", 
        "Gull", "Harrier", "Hawfinch", "Hawk", "Heron", "Herring", "Hobby", "Hoopoe", "Jackdaw", "Jay", "Kestrel", 
        "Kingfisher", "Kite", "Kittiwake", "Knot", "Lapwing", "Lark", "Linnet", "Magpie", "Mallard", "Mandarin", 
        "Merlin", "Moorhen", "Nightingale", "Nightjar", "Nuthatch", "Oriole", "Osprey", "Ostrich", "Owl",
        "Oystercatcher", "Parakeet", "Parrot", "Partridge", "Pelican", "Peregrine", "Pheasant", "Pigeon",
        "Pintail", "Pipit", "Plover", "Pochard", "Puffin", "Quail", "Raven", "Razorbill", "Redpoll", "Redshank",
        "Redstart", "Redwing", "Robin", "Rook", "Ruff", "Sanderling", "Sandpiper", "Scaup", "Scoter", "Shelduck",
        "Shoveler", "Shrike", "Siskin", "Skua", "Skylark", "Smew", "Snipe", "Sparrow", "Sparrowhawk", "Spoonbill",
        "Starling", "Stint", "Stonechat", "Stork", "Swallow", "Swan", "Swift", "Teal", "Tern", "Thrush",
        "Treecreeper", "Turnstone", "Twite", "Vulture", "Wagtail", "Warbler", "Waxwing", "Wheatear", "Whimbrel",
        "Whinchat", "Whitethroat", "Wigeon", "Woodcock", "Woodlark", "Woodpigeon", "Woodpecker", "Wren", "Wryneck",
        "Yellowhammer"
      },
      
      new string[] // Insects
      {
        "Ant", "Aphid", "Bee", "Beetle", "Butterfly", "Caterpillar", "Dragonfly", "Firefly", "Fly", "Gnat", "Grasshopper", 
        "ladybird", "Wasp", "Woodlouse"
      },
      
      new string[] // Fish
      {
        "carp", "cod", "goldfish", "haddock", "Halibut", "mackeral", "minnow", "plaice", "salmon", "trout", "tuna"
      },

      new string[] // Sea Creatures
      {
        "dolphin", "fish", "lobster", "octopus", "oyster", "seal", "seahorse", "shark", "shrimp", "squid", "whale"
      },
      
      new string[] // Sports
      {
        "badminton", "basketball", "diving", "football", "golf", "gymnastics", "hockey", "jogging", "pool", 
        "racing", "rugby", "running", "rowing", "skiing", "snooker", "speedway", "soccer", "swimming", "tennis", "volleyball"
      },
      
      new string[] // Instruments
      {
        "Bassoon", "Bells", "Cello", "Clarinet", "Cymbal", "Drum", "Euphonium", "Flute", "Glockenspiel", 
        "Guitar", "Horn", "Keyboard", "Lute", "Oboe", "Piano", "Piccolo", "Recorder", "Saxophone", "Timpani", 
        "Triangle", "Trombone", "Trumpet", "Tuba", "Viola", "Violin", "Xylophone"
      },
      
      new string[] // Careers
      {
        "accountant", "architect", "astronaut", "bard", "beekeeper", "butler", "cameraman", "carpenter", "cook",
        "courier", "director", "doctor", "engineer", "fireman", "journalist", "judge", "landlord", "lawyer", 
        "maid", "mechanic", "nurse", "pilot", "policeman", "programmer", "receptionist", "sailor", "salesman", 
        "soldier", "waiter"
      },
      
      new string[] // Vehicles
      {
        "aeroplane", "bicycle", "bike", "boat", "bus", "car", "glider", "helicopter", "lorry", "moped", "motorbike", 
        "scooter", "ship", "tandem", "tank", "taxi", "tractor", "train", "tram", "tricycle", "zeppelin"
      },
      
      new string[] // Geography
      {
        "aftershock", "beach", "chasm", "continent", "desert", "earthquake", "fjord", "glacier", "gorge", 
        "iceberg", "island", "land", "lake", "lava", "oasis", "ocean", "magma", "mountain", "ocean", "river",
        "rock", "sand", "sea", "stream", "tremor", "volcano"
      },
      
      new string[] // Colours
      {
        "Aqua", "Aquamarine", "Beige", "Black", "Blue", "Brown", "Cream", "Crimson", "Cyan", "Gold", "Green",
        "Grey", "Indigo", "Ivory", "Khaki", "Lime", "Magenta", "Maroon", "Navy", "Olive", "Orange", "Pink",
        "Plum", "Purple", "Red", "Sienna", "Silver", "Turquoise", "Violet", "White", "Yellow"
      },
      
      new string[] // Chemical Elements
      {
        "Actinium", "Aluminium", "Americium", "Antimony", "Argon", "Arsenic", "Astatine", "Barium", "Berkelium",
        "Beryllium", "Bismuth", "Bohrium", "Boron", "Bromine", "Cadmium", "Calcium", "Californium", "Carbon",
        "Cerium", "Cesium", "Chlorine", "Chromium", "Cobalt", "Copper", "Curium", "Darmstadtium", "Dubnium",
        "Dysprosium", "Einsteinium", "Erbium", "Europium", "Fermium", "Fluorine", "Francium", "Gadolinium",
        "Gallium", "Germanium", "Gold", "Hafnium", "Hassium", "Helium", "Holmium", "Hydrogen", "Indium",
        "Iodine", "Iridium", "Iron", "Krypton", "Lanthanum", "Lawrencium", "Lead", "Lithium", "Lutetium",
        "Magnesium", "Manganese", "Meitnerium", "Mendelevium", "Mercury", "Molybdenum", "Neodymium", "Neon",
        "Neptunium", "Nickel", "Niobium", "Nitrogen", "Nobelium", "Osmium", "Oxygen", "Palladium", "Phosphorus",
        "Platinum", "Plutonium", "Polonium", "Potassium", "Praseodymium", "Promethium", "Protactinium",
        "Radium", "Radon", "Rhenium", "Rhodium", "Rubidium", "Ruthenium", "Rutherfordium", "Samarium",
        "Scandium", "Seaborgium", "Selenium", "Silicon", "Silver", "Sodium", "Strontium", "Sulfur",
        "Tantalum", "Technetium", "Tellurium", "Terbium", "Thallium", "Thorium", "Thulium", "Tin", "Titanium",
        "Tungsten", "Ununbium", "Ununhexium", "Ununoctium", "Ununpentium", "Ununquadium", "Ununseptium",
        "Ununtrium", "Ununium", "Uranium", "Vanadium", "Xenon", "Ytterbium", "Yttrium", "Zinc", "Zirconium"
      },
      
      new string[] // Weather
      {
        "autumn", "breeze", "cloud", "cyclone", "fog", "hail", "hurricane", "rain", "sleet", "snow", "spring", 
        "storm", "summer", "sunshine", "tornado", "wind", "winter"
      },
      
      new string[] // Tools
      {
        "anvil", "axe", "bucket", "chisel", "fork", "hammer", "hoe", "hook", "knife", "lasso", "pickaxe",
        "pliers", "plow", "rake", "sander", "saw", "screwdriver", "shovel", "spade", "scythe", "wheelbarrow",
        "whisk", "wrench"
      },
      
      new string[] // Cities
      {
        "Acapulco", "Algiers", "Amsterdam", "Athens", "Auckland", "Bangkok", "Bonn", "Brussels", "Cairo",
        "Calgary", "Cambridge", "Canberra", "Caracas", "Casablanca", "Delhi", "Dhaka", "Edinburgh", "Florence",
        "Geneva", "Hamburg", "Jerusalem", "Kabul", "Kobe", "London", "Luxor", "Madrid", "Malaga", "Marrakesh",
        "Melbourne", "Minsk", "Mombasa", "Montreal", "Mumbai", "Munich", "Mykonos", "Nairobi", "Nice", "Oslo",
        "Panama", "Paris", "Phuket", "Quebec", "Queenstown", "Santiago", "Saigon", "Sydney", "Tahiti", "Tokyo",
        "Toronto", "Valencia", "Venice", "Vienna", "Washington", "Zurich"
      },
      
      new string[] // Famous People
      {
        "Aphrodite", "Apollo", "Archimedes", "Aristotle", "Caesar", "Chaplin", "Churchill", "Davinci",
        "Dionysius", "Dylan", "Einstein", "Elvis", "Franklin", "Freud", "Galileo", "Gandhi", "Gorbachev",
        "Hippocrates", "Hitler", "Kennedy", "Lenin", "Madonna", "Mandela", "Newton", "Nixon", "Picasso",
        "Plato", "Pythagoras", "Roosevelt", "Shakespear", "Sinatra", "Socrates", "Spielberg", "Thatcher"
      },
      
      new string[] // Composers
      {
        "Amadaeus", "Bach", "Beethoven", "Berlioz", "Bizet", "Brahms", "Chopin", "Dvorak", "Gershwin", "Glinka", 
        "Grieg", "Handel", "Haydn", "Holst", "Liadov", "Mahler", "Monteverdi", "Mozart", "Mussorgsky", 
        "Rachmaninov", "Ravel", "Rossini", "Schubert", "Schumann", "Sibelius", "Strauss", "Stravinsky", 
        "Tchaikovsky", "Verdi", "Vivaldi", "Wagner"
      },
      
      new string[] // Countries
      {
        "Afghanistan", "Albania", "Algeria", "America", "Andorra", "Angola", "Antigua", "Argentina", "Armenia",
        "Australia", "Austria", "Azerbaijan", "Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belarus",
        "Belgium", "Belize", "Benin", "Bermuda", "Bhutan", "Bolivia", "Bosnia", "Botswana", "Brazil", "Bulgaria", 
        "Burma", "Burundi", "Cambodia", "Cameroon", "Canada", "Chad", "Chile", "China", "Colombia", "Comoros", 
        "Congo", "Croatia", "Cuba", "Cyprus", "Denmark", "Djibouti", "Dominica", "Ecuador", "Egypt", "England",
        "Eritrea", "Estonia", "Ethiopia", "Fiji", "Finland", "France", "Gabon", "Gambia", "Georgia",
        "Germany", "Ghana", "Greece", "Grenada", "Guatemala", "Guernsey", "Guinea", "Guyana", "Haiti", "Herzegovina",
        "Holland", "Honduras", "Hungary", "Iceland", "India", "Indonesia", "Iran", "Iraq", "Ireland", "Italy",
        "Jamaica", "Japan", "Jersey", "Jordan", "Kazakhstan", "Kenya", "Kiribati", "Korea", "Kuwait", "Kyrgyzstan",
        "Laos", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libya ", "Liechtenstein", "Lithuania",
        "Luxembourg", "Macedonia", "Madagascar", "Malawi", "Malaysia", "Maldives", "Mali", "Malta",
        "Mauritania", "Mauritius", "Mexico", "Micronesia", "Moldova", "Monaco", "Mongolia", "Montenegro",
        "Morocco", "Mozambique", "Myanmar", "Namibia", "Nauru", "Nepal", "Netherlands", "Nicaragua", "Niger",
        "Nigeria", "Norway", "Oman", "Pakistan", "Palau", "Palestine", "Panama", "Paraguay", "Peru",
        "Philippines", "Poland", "Portugal", "Qatar", "Romania", "Russia", "Rwanda", "Samoa", "Scotland",
        "Senegal", "Serbia", "Seychelles", "Singapore", "Slovakia", "Slovenia", "Somalia", "Spain", "Sudan",
        "Suriname", "Swaziland", "Sweden", "Switzerland", "Syria", "Taiwan", "Tajikistan", "Tanzania",
        "Thailand", "Togo", "Tonga", "Trinidad", "Tobago", "Tunisia", "Turkey", "Turkmenistan", "Tuvalu",
        "Uganda", "Ukraine", "Uruguay", "Uzbekistan", "Vanuatu", "Venezuela", "Vietnam", "Wales", "Yemen",
        "Yugoslavia", "Zaire", "Zambia"
      },
      
      new string[] // Clothes
      {
        "Anorak", "Belt", "Blouse", "Boots", "Cap", "Cardigan", "Coat", "Dress", "Gloves", "Hat", "Jacket",
        "Jeans", "Jumper", "Knickers", "Overcoat", "Pyjamas", "Pants", "Pantyhose", "Raincoat", "Scarf",
        "Shirt", "Shoes", "Skirt", "Slacks", "Slippers", "Socks", "Stockings", "Suit", "Sweater",
        "Sweatshirt", "Tie", "Tights", "Trainers", "Trousers", "Vest"
      },
      
      new string[] // The Universe
      {
        "Andromeda", "Asteroid", "Cluster", "Comet", "Earth", "Galaxy", "Jupiter", "Mars", "Mercury", "Meteorite",
        "Moon", "Nebula", "Neptune", "Planet", "Pluto", "Saturn", "Star", "Sun", "Universe", "Uranus", "Venus"
      },
      
      new string[] // Around The Home
      {
        "attic", "basement", "bath", "bathroom", "bed", "bedroom", "blanket", "bookcase", "carpet", "ceiling",
        "cellar",  "chair", "chimney", "closet", "couch", "cup", "cupboard", "curtain", "cushion", "cutlery", 
        "desk", "dish", "dishwasher", "door", "doorstep", "drapes", "fan", "fascia", "faucet", "fireplace", 
        "floor", "foundation", "furniture", "glass", "grater", "guttering", "hall", "hallway", "kettle", 
        "kitchen", "landing", "liquidiser", "lounge", "microwave", "mirror", "oven", "plate", "plumbing", 
        "porch", "rafter", "roof", "room", "rug", "saucepan", "scales", "shelf", "shower", "sink", "spoon", "sofa", 
        "stairs", "table", "tap", "teapot", "television", "toaster", "toilet", "utensil", "utility", "video", 
        "wall", "window", "wire"
      },
      
      new string[] // Computing
      {
        "Applet", "Client", "Communication", "Computer", "Development", "Disc", "Distributed", "Download", "Drive", 
        "Driver", "Efficiency", "Firewall", "Graphics", "Hardware", "Internet", "Keyboard", "Java", "Javascript", "linux", 
        "Memory", "Modem", "Monitor", "Mouse", "Network", "processing", "processor", "program", "Router", "Screen", 
        "Server", "Software", "Virtual", "Web", "Windows"
      },
      
      new string[] // Time
      {
        "nanosecond", "millisecond", "second", "minute", "hour", "day", "week", "fortnight", "month", "year", 
        "decade", "century", "millenium", "January", "February", "March", "April", "May", "June", "July", "August", 
        "September", "October", "November", "December", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", 
        "Saturday", "Sunday", "Christmas", "Easter", "Whitsun", "Valentines"
      },
      
      new string[] // Building Materials
      {
        "bricks", "cement", "concrete", "mortar", "nail", "paint", "plaster", "plywood", "screw", "steel", "wood"
      },

      new string[] // Nuts
      {
        "almond", "brazil", "cashew", "chestnut", "hazelnut", "Macadamia", "Peanut", "Pecan", "Pistachio", "walnut"
      }
    };    
    
    public RandomWordManager()
    {
      DateTime aTime = new DateTime(1000);
      aTime = DateTime.Now;
      int nSeed = (int)(aTime.Millisecond);
      RandomPick = new Random(nSeed);
      RandomCategory = new Random(nSeed+1);
    }

    public string Pick()
    {
      string newword = "";
      category = (int)(RandomCategory.Next(0,categories.GetLength(0)));
      int index = (int)(RandomPick.Next(0, words[category].GetLength(0)));
      newword = words[category][index];
      newword = newword.ToUpper();
      return newword;
    }
    
    public void drawCategory(Graphics g)
    {
      g.DrawString("Category : " + categories[category], new Font("Arial", 10), new SolidBrush(Color.Blue), 200, 30);
    }
  }
}
