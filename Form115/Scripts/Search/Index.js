$(function () {
    $("#listeContinents").change(loadRegions);
    $("#listeRegions").change(loadPays);
    $("#listePays").change(loadVilles);

    $("#SearchBtn").click(saveSearchOptions);

    // DateTimePicker
    $("#DateDepart").datepicker({
        format: "mm/dd/yyyy",
        todayBtn: "linked",
        language: "fr",
        autoclose: true,
        todayHighlight: true,
        minDate: "+1d"
    });

});


function loadRegions() {
    IdContinent = $("#listeContinents").val();
    var str = '<option value="0">Sélectionner une région</option>';
    if (IdContinent != 0) {
        $.getJSON("/Browse/GetJSONRegions/" + IdContinent, function (data) {

            // $.each(data, function (idx, mar) {
            // str += '<optgroup  label="' + mar.Marque + '">'
            $.each(data, function (idx, region) {
                str += '<option value="' + region.Id + '">' + region.Nom + "</option>";

            });
            //    str += '</optgroup>';
            //});
            $("#listeRegions").prop('disabled', false);
            $("#listeRegions").html(str);
            $("#listeRegions").val('0');
        });
    }
    else
    {
        $("#listeRegions").html(str);
        $("#listeRegions").val('0');
        $("#listeRegions").prop('disabled', true);
    }
    $("#listePays").html('<option value="0">Sélectionner un pays</option>');
    $("#listeVilles").html('<option value="0">Sélectionner une ville</option>');
    $("#listePays").prop('disabled', true);
    $("#listeVilles").prop('disabled', true);
}

function loadPays() {
    IdRegion = $("#listeRegions").val();
    var str = '<option value="0">Sélectionner un pays</option>';
    if (IdRegion != 0)
    {
        $.getJSON("/Browse/GetJSONPays/" + IdRegion, function (data) {

            // $.each(data, function (idx, mar) {
            // str += '<optgroup  label="' + mar.Marque + '">'
            $.each(data, function (idx, pays) {
                str += '<option value="' + pays.Id + '">' + pays.Nom + "</option>";

            });
            //    str += '</optgroup>';
            //});
            $("#listePays").prop('disabled', false);
            $("#listePays").html(str);
            $("#listePays").val('0');
        });
    }
    else {
        $("#listePays").prop('disabled', true);
        $("#listePays").html(str);
        $("#listePays").val('0');
    }
    $("#listeVilles").html('<option value="0">Sélectionner une ville</option>');
    $("#listeVilles").prop('disabled', true);
}


function loadVilles() {
    IdPays = $("#listePays").val();
    var str = '<option value="0">Sélectionner une ville</option>';
    if (IdPays != 0) {
        $.getJSON("/Browse/GetJSONVilles/" + IdPays, function (data) {

            // $.each(data, function (idx, mar) {
            // str += '<optgroup  label="' + mar.Marque + '">'
            $.each(data, function (idx, ville) {
                str += '<option value="' + ville.Id + '">' + ville.Nom + "</option>";

            });
            $("#listeVilles").prop('disabled', false);
            $("#listeVilles").html(str);
            $("#listeVilles").val('0');
            //    str += '</optgroup>';
            //});
        });
    }
    else {
        $("#listeVilles").prop('disabled', true);
        $("#listeVilles").html(str);
        $("#listeVilles").val('0');
    }
}

function saveSearchOptions() {
    // IdContinent = $("#listeContinents").val();
    // IdRegion = $("#listeRegions").val();
    // IdPays = $("#listePays").val();
    // IdVille = $("#listeVille").val();
    var DateDepart = $("#DateDepart").val();
    var Duree = $("#Duree").val();
    var NbPers = $("#NbPers").val();
    sessionStorage.setItem("DateDepart", DateDepart);
    sessionStorage.setItem("Duree", Duree);
    sessionStorage.setItem("NbPers", NbPers);
}