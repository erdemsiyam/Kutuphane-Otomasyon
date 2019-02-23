
$(document).ready(function myfunction() {


        $(".kitap-ara-1").click(function myfunction() {	
            var aranacak_kelime = $(".aranacak-kelime").val();
            $.ajax({
                type: "POST",
                url: "/home/_aramaKitapListele",
                data: { ara: aranacak_kelime },	
                dataType: "html", 
                success: function myfunction(veri) {	
                    $(".kitaplar").html(veri);
                },
                error: function myfunction(xhr, textStatus, err) {

                    alert("responseText: " + xhr.responseText);
                }
            });
        });

        $(".kitap-ara-2").click(function myfunction() {
            var arama1 = $(".secim1 option:selected").val();
            var arama2 = $(".secim2 option:selected").val();
            $.ajax({
                type: "POST",
                url: "/home/_filtreleSiralaKitapListele",
                data: { ara1: arama1, ara2: arama2 },
                dataType: "html",
                success: function myfunction(veri) {
                    $(".kitaplar").html(veri);
                },
                error: function myfunction(xhr, textStatus, err) {

                    alert("responseText: " + xhr.responseText);
                }
            });
        });

    })


