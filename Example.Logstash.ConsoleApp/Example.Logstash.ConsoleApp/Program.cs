using Serilog;
using Serilog.Sinks.Network;

var projectName = "test";
var id = 3;

Log.Logger = new LoggerConfiguration()
    .WriteTo.TCPSink("tcp://localhost:5003")
    // .WriteTo.UDPSink("udp://localhost",5001)
    .Enrich.WithProperty("project_name",projectName)
    .CreateLogger();

Log.Information("Uygulama Başladı");

Log.Information("{id}'li Kullanıcı Bir Post Paylaştı", id);

var photoPath = "C:\\Users\\abdbl\\OneDrive\\Belgeler\\elasticsearch-logstash\\Example.Logstash.ConsoleApp\\Example.Logstash.ConsoleApp\\images\\crafterdevs.png";

if(File.Exists(photoPath)){
    byte[] imageBytes = File.ReadAllBytes(photoPath);
    string base64Image = Convert.ToBase64String(imageBytes);
    string RequestBody = Convert.ToBase64String(imageBytes);

    Log.Information("Kullanıcı fotoğrafı başarıyla yüklendi: {Base64Image}", base64Image);
    
    Log.Information("{RequestBody}", RequestBody);
}
else
{
    Log.Warning("Yüklenen fotoğraf bulunamadı: {PhotoPath}", photoPath);
}

Log.Fatal("Uygulama da bir hata oluştu");
