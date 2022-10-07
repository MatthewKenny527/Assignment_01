//The extra marks that were done in this file was to go to and from latex.
namespace Assignment01
{
    public class Program
    {
        public static UniversalData data;
        public static bool verboso= false;
        private String orginalFormat="";
        private String newFormat="";
        static void Main(string[] args)
        {
            //This is the switch statement that finds what the user wants such as -h for help and -v for verbose
            for(int i =0; i<args.Length; i++){
                switch(args[i]){
                    
                    case "-v":
                    verboso=true;
                    break;

                    case "-l":
                    Console.WriteLine("File types: \n.md\n.json\n.csv\n.html");
                    break;

                    case "-h":
                    Console.WriteLine(   "-v,	—verbose	 	 	 	        Verbose	mode	(debugging	output	to	STDOUT)"
                                        +"\n-o	<file>,	—output=<file>	                        Output	file	specified	by	<file>"
	                                    +"\n-l,	—list-formats	 	 	                List	formats"
	                                    +"\n-h,	—help		 	 	 	        Show	usage	message"
	                                    +"\n-i,	—info		 	 	 	        Show	version	information	");
                    break;

                    case "-i":
                    Console.WriteLine("Version --1.001");
                    break;

                    case "-o":
                    string orginalFile =args[i-1];
                    string nextFile=args[i+1];
                    String[] oFile=orginalFile.Split('.');
                    String[] nFile=nextFile.Split('.');
                    UniversalData x= new UniversalData(oFile[0],nFile[0],oFile[1],nFile[1]);
                    if(verboso==true){
                        Console.WriteLine("Converting "+oFile[1]+" to "+nFile[1]+ "....");
                    }
                    data=x;
                    orginalToUniversal.Formater();
                    break;
                }
            }
        }
        //public static 

    }
}