function IsoDate(jsonDate) {
    var dateString = jsonDate.DateTime.toString();
    var aDate = new Date(parseInt(dateString.replace(/\/Date\((\d+)\)\//, '$1')));
    return ISODateString(aDate);
}
function IsoDateMinus2(jsonDate) {
    var dateString = jsonDate.DateTime.toString();
    var aDate = new Date(parseInt(dateString.replace(/\/Date\((\d+)\)\//, '$1')));
    aDate = aDate.addDays(-3);
    return ISODateString(aDate);
}
function ISODateString(d) {
    function pad(n) { return n < 10 ? '0' + n : n }
    return d.getUTCFullYear() + '-'
      + pad(d.getUTCMonth() + 1) + '-'
      + pad(d.getUTCDate()) + 'T'
      + pad(d.getUTCHours()) + ':'
      + pad(d.getUTCMinutes()) + ':'
      + pad(d.getUTCSeconds()) + 'Z'
}

function getSites(baseurl, method) {
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: "ExampleData.svc/ListSites",
        data: null,
        dataType: "json",
        success: function (msg) {

           // alert(msg.d[1].SiteName);
            // Hide the fake progress indicator graphic.
            $('#RSSContent').removeClass('loading');
            $('#RSSContent').addClass('urlLists');
            for (site in msg.d) {
                // alert(msg.d[site].SiteName);

                // Insert the returned HTML into the <div>.
                //$('#RSSContent').text(msg.d);

                var link = baseurl + method + '?location=' + networkCode + ':' + msg.d[site].SiteCode;
                $('#RSSContent').append(
                        '<div><span>' + msg.d[site].SiteName + '</span><a href="' + link + '">' + link + '</a></div>'
                           );
            };



        },
        error: function () { alert("error"); }
    });
}
function getSeries(baseurl, method) {
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: "ExampleData.svc/ListSeries",
        data: null,
        dataType: "json",
        success: function (msg) {

           // alert(msg.d[1].SiteName);
            // Hide the fake progress indicator graphic.
            $('#RSSContent').removeClass('loading');
            $('#RSSContent').addClass('urlLists');
            for (site in msg.d) {
                // alert(msg.d[site].SiteName);

                // Insert the returned HTML into the <div>.
                //$('#RSSContent').text(msg.d);

                var link = baseurl + method + '?location=' + networkCode + ':' + msg.d[site].SiteCode + '&variable=' + vocabularyCode + ':' + msg.d[site].VariableCode
                   + '&startDate=' + IsoDateMinus2(msg.d[site].EndDateTime) + '&endDate=' + IsoDate(msg.d[site].EndDateTime);
                $('#SeriesContent').append(
                        '<div><span>' + msg.d[site].SiteName + '</span><a href="' + link + '">' + link + '</a></div>'
                           );
            };



        },
        error: function () { alert("error"); }
    });
}