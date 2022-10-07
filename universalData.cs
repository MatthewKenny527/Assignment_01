//This class is for storing all of the table data after it is extracted from the table format the the user reads in.
namespace Assignment01{
    public class UniversalData{
        private string oldFormat;
        private string fileName;
        private string newFileName;
        private string newFormat;
        string[]headers;
        string[]data;
        public UniversalData(string fileName,string newFileName,string oldFormat,string newFormat){
            this.oldFormat=oldFormat;
            this.newFormat=newFormat;
            this.fileName=fileName;
            this.newFileName=newFileName;
        }
        public string getOldFormat(){
            return oldFormat;
        }

        public string getnewFormat(){
            return newFormat;
        }
        public string[] getHeaders(){
            return headers;
        }
        public string[] getData(){
            return data;
        }
        public string getFileName(){
            return fileName;
        }
        public string getNewFileName(){
            return newFileName;
        }

        public void setHeaders(string[] x){
            headers=x;
        }
        public void setData(string[]x){
            data=x;
        }
    }
}