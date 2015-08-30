﻿$(function () {
    $("#champDateDepart").datepicker({
        format: "dd/mm/yyyy",
        todayBtn: "linked",
        language: "fr",
        autoclose: true,
        todayHighlight: true,
        minDate: "0" // A reprendre
    });

    loadSearchParams();

    $("input").change(chargerListeProduits);
    chargerListeProduits();
});

function chargerListeProduits() {
    console.log("Fonction appelée.");
    var tbodyListeProduits = $("#tbodyListeProduits");
    var obj = {
        IdHotel: $("[name=IdHotel]").val(),
        DateDepart: $("[name=DateDepart]").val(),
        DureeMinSejour: $("[name=DureeMinSejour]").val(),
        DureeMaxSejour: $("[name=DureeMaxSejour]").val(),
        DateDebut: $("[name=DateDebut]").val(),
        DateFin: $("[name=DateFin]").val(),
    };
    console.log(obj);
    $.post(
        '/Hotel/listeProduits',
        obj,
        function (data) {
            console.log("Requête effectuée et réponse reçue.");
            console.log(data);
            var str = "";
            if (data.length == 0) {
                $("#tbodyListeProduits").html('<tr><td colspan="0" class="colspan0">Aucun résultat</td></tr>');
            }
            else {
                $.each(data, function (index, item) {
                    str += "<tr>";
                    str += "<td>" + item.date + "</td>";
                    str += "<td>" + item.duree + " jours</td>";
                    // TODO CSS
                    if (item.promotions == 0) {
                        str += "<td style='text-align:right'>" + item.prix + "€</td>";
                    }
                    else {
                        str += "<td style='text-align:right'><s>" + item.prix + '€</s> <span class="alert-info">' + item.prixSolde + "€</span> </td>";
                    }
                    str += "<td style='text-align:right'>" + item.nb_restants + "</td>";
                    str += "</tr>";
                });
                console.log("each exécuté.")
                $("#tbodyListeProduits").html(str);
            }
        }
    );
}

function loadSearchParams() {
    var DateDepart = sessionStorage.getItem("DateDepart");
    var Duree = sessionStorage.getItem("Duree");
    //var NbPers = sessionStorage.getItem(NbPers);

    var DureeMin = (Duree != null) ? Math.max(1, Duree - 2) : 1;
    var DureeMax = (Duree != null) ? parseInt(Duree) + 2 : null;

    $("[name=DateDepart]").val(DateDepart);
    $("[name=DureeMinSejour]").val(DureeMin) ;
    $("[name=DureeMaxSejour]").val(DureeMax);
}