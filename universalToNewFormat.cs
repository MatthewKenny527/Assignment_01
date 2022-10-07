//This class is used to convert the universal data into the newformat the user has ask for. The that is add to the file the user ask for.
namespace Assignment01{
    public class universalToNewFormat{
        public static void NewFormater(){
            UniversalData data = Program.data;
            String file = data.getnewFormat();
            if(Program.verboso==true){
                Console.WriteLine();
                Console.WriteLine("Converting "+file+" to universal format....");
            }
            //Console.WriteLine(file);
            switch(file){
                case "json":
                UniToJson();
                break;

                case "md":
                UniToMd();
                break;

                case "html":
                UniToHtml();
                break;

                case "csv":
                UniToCsv();
                break;

                case "ltx":
                UniToLtx();
                break;
            }
        }
        public static void UniToJson(){
            UniversalData data = Program.data;
            String[] headers=data.getHeaders();
            String[] info=data.getData();
            int infoTracker=0;
            String fileBuilder="[";
            int objectCount = info.Length/headers.Length;
            for(int i=0;i<objectCount;i++){
                fileBuilder=fileBuilder+"{";
                for(int j=0;j<headers.Length;j++){
                    bool isheaderNum = int.TryParse(headers[j], out int n);
                    bool isInfoNum=int.TryParse(info[j+infoTracker],out int k);
                    if(isInfoNum==false){
                        if(j<headers.Length-1)
                            fileBuilder=fileBuilder+"\""+headers[j]+"\""+":"+" "+"\""+info[j+infoTracker]+"\""+",\n";
                        else if(j==headers.Length-1){
                            fileBuilder=fileBuilder+"\""+headers[j]+"\""+":"+" "+"\""+info[j+infoTracker]+"\""+"\n";
                        }
                    }
                    else{
                        if(j<headers.Length-1)
                            fileBuilder=fileBuilder+"\""+headers[j]+"\""+":"+" "+info[j+infoTracker]+",\n";
                        else if(j==headers.Length-1)
                            fileBuilder=fileBuilder+"\""+headers[j]+"\""+":"+" "+info[j+infoTracker]+"\n";
                    }
                }
                infoTracker=infoTracker+headers.Length;
                if(i<objectCount-1)
                    fileBuilder=fileBuilder+"},";
                else if(i==objectCount-1)
                    fileBuilder=fileBuilder+"}";
            }
            fileBuilder=fileBuilder+"]";

            if(Program.verboso==true){
                Console.WriteLine();
                Console.WriteLine("Converted to "+Program.data.getnewFormat());
                Console.WriteLine(fileBuilder);
            }
            string sendFile = fileBuilder + Environment.NewLine;
            File.WriteAllText(data.getNewFileName()+"."+data.getnewFormat(), sendFile);
            
            //Console.WriteLine(string.Join(',',headers));
        }
        public static void UniToMd(){
            UniversalData data = Program.data;
            String[] headers=data.getHeaders();
            String[] info=data.getData();
            int objectCount = info.Length/headers.Length;
            int infoTracker=0;
            String fileBuilder="|";
            for(int i=0;i<headers.Length;i++){
                fileBuilder=fileBuilder + headers[i]+"|";
            }
            fileBuilder=fileBuilder+"\n|";

            for(int i=0;i<headers.Length;i++){
                fileBuilder=fileBuilder+"-|";
            }

            for(int i=0;i<objectCount;i++){
                fileBuilder=fileBuilder+"\n|";
                for(int j=0;j<headers.Length;j++){
                    fileBuilder=fileBuilder+info[j+infoTracker]+"|";
                }
                infoTracker = infoTracker+headers.Length;
            }
            if(Program.verboso==true){
                Console.WriteLine();
                Console.WriteLine("Converted to "+Program.data.getnewFormat());
                Console.WriteLine(fileBuilder);
            }
            string sendFile = fileBuilder + Environment.NewLine;
            File.WriteAllText(data.getNewFileName()+"."+data.getnewFormat(), sendFile);
        }
        public static void UniToHtml(){
            UniversalData data = Program.data;
            String[] headers=data.getHeaders();
            String[] info=data.getData();
            int infoTracker=0;
            String fileBuilder="<table>\n<tr>";
            int objectCount = info.Length/headers.Length;

            for(int i=0;i<headers.Length;i++){
                fileBuilder=fileBuilder+"\n<th>"+headers[i]+"</th>";
            }
            fileBuilder=fileBuilder+"\n</tr>";

            for(int i=0;i<objectCount;i++){
                fileBuilder=fileBuilder+"\n<tr>";
                for(int j=0;j<headers.Length;j++){
                    fileBuilder=fileBuilder+"\n<td>"+info[j+infoTracker]+"</td>";
                }
                fileBuilder=fileBuilder+"\n</tr>";
                infoTracker = infoTracker+headers.Length;
            }
            fileBuilder=fileBuilder+"\n</table>";

            if(Program.verboso==true){
                Console.WriteLine();
                Console.WriteLine("Converted to "+Program.data.getnewFormat());
                Console.WriteLine(fileBuilder);
            }
            string sendFile = fileBuilder + Environment.NewLine;
            File.WriteAllText(data.getNewFileName()+"."+data.getnewFormat(), sendFile);
        }
        public static void UniToCsv(){
            UniversalData data = Program.data;
            String[] headers=data.getHeaders();
            String[] info=data.getData();
            int infoTracker=0;
            String fileBuilder="";
            int objectCount = info.Length/headers.Length;

            
            for(int j=0;j<headers.Length;j++){
                bool isheaderNum = int.TryParse(headers[j], out int n);
                if(isheaderNum==false){
                    if(j>0)
                        fileBuilder=fileBuilder+",\""+headers[j]+"\"";
                    else{
                        fileBuilder=fileBuilder+"\""+headers[j]+"\"";
                    }
                }
                else{
                    if(j>0)
                        fileBuilder=fileBuilder+","+headers[j];
                    else{
                        fileBuilder=fileBuilder+headers[j];
                    }
                }
                   
            }
            for(int i=0;i<objectCount;i++){
                fileBuilder=fileBuilder+"\n";
                for(int j=0;j<headers.Length;j++){
                    bool isinfoNum = int.TryParse(info[j+infoTracker], out int n);
                    if(isinfoNum==false){
                    if(j>0)
                        fileBuilder=fileBuilder+",\""+info[j+infoTracker]+"\"";
                    else{
                        fileBuilder=fileBuilder+"\""+info[j+infoTracker]+"\"";
                    }
                }
                else{
                    if(j>0)
                        fileBuilder=fileBuilder+","+info[j+infoTracker];
                    else{
                        fileBuilder=fileBuilder+info[j+infoTracker];
                    }
                }
                }
                infoTracker=infoTracker+headers.Length;
            }
            if(Program.verboso==true){
                Console.WriteLine();
                Console.WriteLine("Converted to "+Program.data.getnewFormat());
                Console.WriteLine(fileBuilder);
            }
            string sendFile = fileBuilder + Environment.NewLine;
            File.WriteAllText(data.getNewFileName()+"."+data.getnewFormat(), sendFile);
                
            
        }
        public static void UniToLtx(){
            UniversalData data = Program.data;
            String[] headers=data.getHeaders();
            String[] info=data.getData();
            int infoTracker=0;
            String fileBuilder="\\begin{center}\n\\begin{tabular}{ |";
            int objectCount = info.Length/headers.Length;
            for(int i=0;i<headers.Length;i++){
                fileBuilder=fileBuilder+ "c|";
            }
            fileBuilder=fileBuilder+" }\n\\hline\n";

            for(int i=0;i<headers.Length;i++){
                if(i==headers.Length-1)
                    fileBuilder=fileBuilder + headers[i];
                else{
                    fileBuilder=fileBuilder + headers[i]+" & ";
                }    
            }
            fileBuilder=fileBuilder+ "\\\\\n\\hline\n";
            for(int j=0;j<objectCount;j++){
                for(int i=0;i<headers.Length;i++){
                    if(i==headers.Length-1)
                        fileBuilder=fileBuilder + info[i+infoTracker];
                    else{
                        fileBuilder=fileBuilder + info[i+infoTracker]+" & ";
                    }    
                }
                fileBuilder=fileBuilder+ " \\\\\n";
                infoTracker=infoTracker+headers.Length;
            }
            fileBuilder=fileBuilder+"\\hline\n\\end{tabular}\n\\end{center}";
            //fileBuilder=fileBuilder+ "\\\\\n";
            if(Program.verboso==true){
                Console.WriteLine();
                Console.WriteLine("Converted to "+Program.data.getnewFormat());
                Console.WriteLine(fileBuilder);
            }
            string sendFile = fileBuilder + Environment.NewLine;
            File.WriteAllText(data.getNewFileName()+"."+data.getnewFormat(), sendFile);
                
        }
    }
}