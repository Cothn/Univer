/*
   Licensed to the Apache Software Foundation (ASF) under one or more
   contributor license agreements.  See the NOTICE file distributed with
   this work for additional information regarding copyright ownership.
   The ASF licenses this file to You under the Apache License, Version 2.0
   (the "License"); you may not use this file except in compliance with
   the License.  You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/
var showControllersOnly = false;
var seriesFilter = "";
var filtersOnlySampleSeries = true;

/*
 * Add header in statistics table to group metrics by category
 * format
 *
 */
function summaryTableHeader(header) {
    var newRow = header.insertRow(-1);
    newRow.className = "tablesorter-no-sort";
    var cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 1;
    cell.innerHTML = "Requests";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 3;
    cell.innerHTML = "Executions";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 6;
    cell.innerHTML = "Response Times (ms)";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 1;
    cell.innerHTML = "Throughput";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 2;
    cell.innerHTML = "Network (KB/sec)";
    newRow.appendChild(cell);
}

/*
 * Populates the table identified by id parameter with the specified data and
 * format
 *
 */
function createTable(table, info, formatter, defaultSorts, seriesIndex, headerCreator) {
    var tableRef = table[0];

    // Create header and populate it with data.titles array
    var header = tableRef.createTHead();

    // Call callback is available
    if(headerCreator) {
        headerCreator(header);
    }

    var newRow = header.insertRow(-1);
    for (var index = 0; index < info.titles.length; index++) {
        var cell = document.createElement('th');
        cell.innerHTML = info.titles[index];
        newRow.appendChild(cell);
    }

    var tBody;

    // Create overall body if defined
    if(info.overall){
        tBody = document.createElement('tbody');
        tBody.className = "tablesorter-no-sort";
        tableRef.appendChild(tBody);
        var newRow = tBody.insertRow(-1);
        var data = info.overall.data;
        for(var index=0;index < data.length; index++){
            var cell = newRow.insertCell(-1);
            cell.innerHTML = formatter ? formatter(index, data[index]): data[index];
        }
    }

    // Create regular body
    tBody = document.createElement('tbody');
    tableRef.appendChild(tBody);

    var regexp;
    if(seriesFilter) {
        regexp = new RegExp(seriesFilter, 'i');
    }
    // Populate body with data.items array
    for(var index=0; index < info.items.length; index++){
        var item = info.items[index];
        if((!regexp || filtersOnlySampleSeries && !info.supportsControllersDiscrimination || regexp.test(item.data[seriesIndex]))
                &&
                (!showControllersOnly || !info.supportsControllersDiscrimination || item.isController)){
            if(item.data.length > 0) {
                var newRow = tBody.insertRow(-1);
                for(var col=0; col < item.data.length; col++){
                    var cell = newRow.insertCell(-1);
                    cell.innerHTML = formatter ? formatter(col, item.data[col]) : item.data[col];
                }
            }
        }
    }

    // Add support of columns sort
    table.tablesorter({sortList : defaultSorts});
}

$(document).ready(function() {

    // Customize table sorter default options
    $.extend( $.tablesorter.defaults, {
        theme: 'blue',
        cssInfoBlock: "tablesorter-no-sort",
        widthFixed: true,
        widgets: ['zebra']
    });

    var data = {"OkPercent": 14.887755102040817, "KoPercent": 85.11224489795919};
    var dataset = [
        {
            "label" : "KO",
            "data" : data.KoPercent,
            "color" : "#FF6347"
        },
        {
            "label" : "OK",
            "data" : data.OkPercent,
            "color" : "#9ACD32"
        }];
    $.plot($("#flot-requests-summary"), dataset, {
        series : {
            pie : {
                show : true,
                radius : 1,
                label : {
                    show : true,
                    radius : 3 / 4,
                    formatter : function(label, series) {
                        return '<div style="font-size:8pt;text-align:center;padding:2px;color:white;">'
                            + label
                            + '<br/>'
                            + Math.round10(series.percent, -2)
                            + '%</div>';
                    },
                    background : {
                        opacity : 0.5,
                        color : '#000'
                    }
                }
            }
        },
        legend : {
            show : true
        }
    });

    // Creates APDEX table
    createTable($("#apdexTable"), {"supportsControllersDiscrimination": true, "overall": {"data": [0.007704081632653061, 500, 1500, "Total"], "isController": false}, "titles": ["Apdex", "T (Toleration threshold)", "F (Frustration threshold)", "Label"], "items": [{"data": [0.007704081632653061, 500, 1500, "HTTP Request"], "isController": false}]}, function(index, item){
        switch(index){
            case 0:
                item = item.toFixed(3);
                break;
            case 1:
            case 2:
                item = formatDuration(item);
                break;
        }
        return item;
    }, [[0, 0]], 3);

    // Create statistics table
    createTable($("#statisticsTable"), {"supportsControllersDiscrimination": true, "overall": {"data": ["Total", 9800, 8341, 85.11224489795919, 27370.66561224489, 189, 350637, 34430.79999999999, 57417.89999999989, 171141.78, 27.947458777498305, 199.48782561106546, 0.725421921074095], "isController": false}, "titles": ["Label", "#Samples", "KO", "Error %", "Average", "Min", "Max", "90th pct", "95th pct", "99th pct", "Transactions\/s", "Received", "Sent"], "items": [{"data": ["HTTP Request", 9800, 8341, 85.11224489795919, 27370.66561224489, 189, 350637, 34430.79999999999, 57417.89999999989, 171141.78, 27.947458777498305, 199.48782561106546, 0.725421921074095], "isController": false}]}, function(index, item){
        switch(index){
            // Errors pct
            case 3:
                item = item.toFixed(2) + '%';
                break;
            // Mean
            case 4:
            // Mean
            case 7:
            // Percentile 1
            case 8:
            // Percentile 2
            case 9:
            // Percentile 3
            case 10:
            // Throughput
            case 11:
            // Kbytes/s
            case 12:
            // Sent Kbytes/s
                item = item.toFixed(2);
                break;
        }
        return item;
    }, [[0, 0]], 0, summaryTableHeader);

    // Create error table
    createTable($("#errorsTable"), {"supportsControllersDiscrimination": false, "titles": ["Type of error", "Number of errors", "% in errors", "% in all samples"], "items": [{"data": ["Non HTTP response code: java.net.SocketException\/Non HTTP response message: Connection reset", 1, 0.011988970147464332, 0.01020408163265306], "isController": false}, {"data": ["Non HTTP response code: java.net.SocketException\/Non HTTP response message: Unrecognized Windows Sockets error: 0: recv failed", 5, 0.05994485073732166, 0.05102040816326531], "isController": false}, {"data": ["500\/Internal Server Error", 10, 0.11988970147464333, 0.10204081632653061], "isController": false}, {"data": ["Non HTTP response code: java.net.SocketException\/Non HTTP response message: Socket closed", 63, 0.755305119290253, 0.6428571428571429], "isController": false}, {"data": ["Non HTTP response code: org.apache.http.conn.HttpHostConnectException\/Non HTTP response message: Connect to senica.minsk-roo.gov.by:443 [senica.minsk-roo.gov.by\\\/195.50.4.146] failed: Connection timed out: connect", 8151, 97.72209567198178, 83.1734693877551], "isController": false}, {"data": ["404\/Not Found", 11, 0.13187867162210767, 0.11224489795918367], "isController": false}, {"data": ["Non HTTP response code: org.apache.http.conn.ConnectTimeoutException\/Non HTTP response message: Connect to senica.minsk-roo.gov.by:443 [senica.minsk-roo.gov.by\\\/195.50.4.146] failed: Read timed out", 100, 1.1988970147464333, 1.0204081632653061], "isController": false}]}, function(index, item){
        switch(index){
            case 2:
            case 3:
                item = item.toFixed(2) + '%';
                break;
        }
        return item;
    }, [[1, 1]]);

        // Create top5 errors by sampler
    createTable($("#top5ErrorsBySamplerTable"), {"supportsControllersDiscrimination": false, "overall": {"data": ["Total", 9800, 8341, "Non HTTP response code: org.apache.http.conn.HttpHostConnectException\/Non HTTP response message: Connect to senica.minsk-roo.gov.by:443 [senica.minsk-roo.gov.by\\\/195.50.4.146] failed: Connection timed out: connect", 8151, "Non HTTP response code: org.apache.http.conn.ConnectTimeoutException\/Non HTTP response message: Connect to senica.minsk-roo.gov.by:443 [senica.minsk-roo.gov.by\\\/195.50.4.146] failed: Read timed out", 100, "Non HTTP response code: java.net.SocketException\/Non HTTP response message: Socket closed", 63, "404\/Not Found", 11, "500\/Internal Server Error", 10], "isController": false}, "titles": ["Sample", "#Samples", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors"], "items": [{"data": ["HTTP Request", 9800, 8341, "Non HTTP response code: org.apache.http.conn.HttpHostConnectException\/Non HTTP response message: Connect to senica.minsk-roo.gov.by:443 [senica.minsk-roo.gov.by\\\/195.50.4.146] failed: Connection timed out: connect", 8151, "Non HTTP response code: org.apache.http.conn.ConnectTimeoutException\/Non HTTP response message: Connect to senica.minsk-roo.gov.by:443 [senica.minsk-roo.gov.by\\\/195.50.4.146] failed: Read timed out", 100, "Non HTTP response code: java.net.SocketException\/Non HTTP response message: Socket closed", 63, "404\/Not Found", 11, "500\/Internal Server Error", 10], "isController": false}]}, function(index, item){
        return item;
    }, [[0, 0]], 0);

});
