$(document).ready(function(){
// ТРЕТИЙ ВАРИАНТ: Текст берется из поля
var client2 = new ZeroClipboard($("#target-to-copy"), {
  moviePath: "ZeroClipboard.swf"
});

client2.on("load", function(client2) {  
  client2.on("complete", function(client2, args) {
    $('#target-to-copy').hide(); // скрываем для наглядности кнопку
  });
});

}); 