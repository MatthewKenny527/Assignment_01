using System.Text.RegularExpressions;

namespace Assignment01{
    public class orginalToUniversal{
        
        public static void Formater(){
            UniversalData data = Program.data;
            String file = data.getOldFormat();
            if(Program.verboso==true){
                Console.WriteLine();
                Console.WriteLine("Converting "+file+" to universal format....");
            }
            //Console.WriteLine(file);
            switch(file){
                case "json":
                JsonToUni();
                break;

                case "md":
                MdToUni();
                break;

                case "html":
                HtmlToUni();
                break;

                case "csv":
                CsvToUni();
                break;

                case "ltx":
                LtxToUni();
                break;

                
            }
        }
        public static void JsonToUni(){
            UniversalData data = Program.data;
            String file =File.ReadAllText(data.getFileName()+"."+data.getOldFormat());
            //Console.WriteLine(file);
            List<String> x = new List<string>();
            List<String> d = new List<string>();
            bool count =false;
            int counter =0;
            foreach (string line in File.ReadAllLines(data.getFileName()+"."+data.getOldFormat())){
                String[] ary =line.Split('"');
                int len = ary.Length;
                if(len<=1){
                    
                    counter++;
                    if(counter==2)
                    count = true;
                }
                else if(len==5){
                    if(count==false)
                        x.Add(ary[1]);
                    d.Add(ary[3]);

                    

                }
                else if(len==3){
                    if(count==false)
                        x.Add(ary[1]);
                    String temp = ary[2];
                    temp =temp.Replace(",","");
                    temp = temp.Replace(" ","");
                    temp = temp.Replace(":","");
                    d.Add(temp);
                }
                
            }
            if(Program.verboso==true){  
                Console.WriteLine();
                Console.WriteLine("Universal Format");
                Console.WriteLine("headers: " +string.Join( "|", x));
                Console.WriteLine("data: "+string.Join( "|", d));
            }
            String[] headers= x.ToArray();
            String[] info =d.ToArray();
            data.setData(info);
            data.setHeaders(headers);
            universalToNewFormat.NewFormater();

            
        }
        public static void MdToUni(){
            UniversalData data = Program.data;
            List<String> x = new List<string>();
            List<String> d = new List<string>();
            int count =0;
            foreach (string line in File.ReadAllLines(data.getFileName()+"."+data.getOldFormat())){
                String[]ary = line.Split('|');
                for(int i=1;i<ary.Length-1;i++){
                    if(count ==0){
                        x.Add(ary[i].Trim());
                    }
                    else if(count==1){
                        continue;
                    }
                    else if(count >0){
                        d.Add(ary[i].Trim());
                    }
                }
                count++;
                
            }
            if(Program.verboso==true){  
                Console.WriteLine();
                Console.WriteLine("Universal Format");
                Console.WriteLine("headers: " +string.Join( "|", x));
                Console.WriteLine("data: "+string.Join( "|", d));
            }
            String[] headers= x.ToArray();
            String[] info =d.ToArray();
            data.setData(info);
            data.setHeaders(headers);
            universalToNewFormat.NewFormater();

        }
        public static void HtmlToUni(){
            UniversalData data = Program.data;
            List<String> x = new List<string>();
            List<String> d = new List<string>();
            //int count =0;
            foreach (string line in File.ReadAllLines(data.getFileName()+"."+data.getOldFormat())){
                if(line.Contains("<table>")||line.Contains("<tr>")||line.Contains("</table>")||line.Contains("</tr>")){
                    continue;
                }
                else if(line.Contains("<th")){
                    String temp = line;
                    string pattern = @"<th[^>]*>{1}";
                    string result = Regex.Replace(temp, pattern, "");
                    result=result.Replace("</th>","");
                    result=result.Trim();
                    x.Add(result);
                }
                else if(line.Contains("<td")){
                    String temp = line;
                    string pattern = @"<td[^>]*>{1}";
                    //Regex rg = new Regex(pattern);  
                    string result = Regex.Replace(temp, pattern, "");
                    
                    result=result.Replace("</td>","");
                    result=result.Trim();
                    d.Add(result);
                }
            }
            if(Program.verboso==true){  
                Console.WriteLine();
                Console.WriteLine("Universal Format");
                Console.WriteLine("headers: " +string.Join( "|", x));
                Console.WriteLine("data: "+string.Join( "|", d));
            }
            String[] headers= x.ToArray();
            String[] info =d.ToArray();
            data.setData(info);
            data.setHeaders(headers);
            universalToNewFormat.NewFormater();
        }
        public static void CsvToUni(){
            UniversalData data = Program.data;
            //String file =File.ReadAllText(data.getFileName()+"."+data.getOldFormat());
            //Console.WriteLine(file);
            List<String> x = new List<string>();
            List<String> d = new List<string>();
            int count =0;
            foreach (string line in File.ReadAllLines(data.getFileName()+"."+data.getOldFormat())){
                String[] ary = line.Split(',');
                 //Console.WriteLine(string.Join( " ", ary));
                
                for(int i=0;i<ary.Length;i++){
                    String[]a=ary[i].Split('"');
                    //Console.WriteLine(string.Join( ",", a));
                    if(a.Length==3 && count==0){
                        x.Add(a[1]);
                    }
                    else if(a.Length==1 && count==0){
                        x.Add(a[0]);
                    }
                    else if(a.Length==3){
                        d.Add(a[1]);
                    }
                    else if(a.Length==1){
                        d.Add(a[0]);
                    }
                }
                
                count++;

            }
            if(Program.verboso==true){  
                Console.WriteLine();
                Console.WriteLine("Universal Format");
                Console.WriteLine("headers: " +string.Join( "|", x));
                Console.WriteLine("data: "+string.Join( "|", d));
            }
            String[] headers= x.ToArray();
            String[] info =d.ToArray();
            data.setData(info);
            data.setHeaders(headers);
            universalToNewFormat.NewFormater();

   
        }
        public static void LtxToUni(){
            UniversalData data = Program.data;
            List<String> x = new List<string>();
            List<String> d = new List<string>();
            int count =0;
            foreach (string line in File.ReadAllLines(data.getFileName()+"."+data.getOldFormat())){
                if(line.Contains("begin")|| line.Contains("end") || line.Equals("\\hline")|| line.Equals("\\hline\\hline"))
                    continue;
                else if(count==0){
                    String temp = line.Replace("\\"," ");
                    temp = temp.Replace("\\hline"," ");
                    String[]a = temp.Split("&");
                    for(int i=0;i<a.Length;i++){
                        x.Add(a[i].Trim());
                    }
                    count++;
                }
                else{
                    String temp = line.Replace("\\"," ");
                    temp = temp.Replace("\\hline"," ");
                    String[]a = temp.Split("&");
                    for(int i=0;i<a.Length;i++){
                        d.Add(a[i].Trim());
                    }
                }


            }
            if(Program.verboso==true){  
                Console.WriteLine();
                Console.WriteLine("Universal Format");
                Console.WriteLine("headers: " +string.Join( "|", x));
                Console.WriteLine("data: "+string.Join( "|", d));
            }
            String[] headers= x.ToArray();
            String[] info =d.ToArray();
            data.setData(info);
            data.setHeaders(headers);
            universalToNewFormat.NewFormater();

        }
       
    }
    
}