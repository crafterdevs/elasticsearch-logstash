using Serilog;
using Serilog.Sinks.Network;

var projectName = "test";
var id = 3;

Log.Logger = new LoggerConfiguration()
    .WriteTo.TCPSink("tcp://localhost:5000")
    // .WriteTo.UDPSink("udp://localhost",5001)
    .Enrich.WithProperty("project_name",projectName)
    .CreateLogger();

Log.Information("Uygulama Başladı");

Log.Information("{id}'li Kullanıcı Bir Post Paylaştı", id);


Console.ReadLine();

Log.Fatal("Uygulama da bir hata oluştu");

Console.ReadLine();