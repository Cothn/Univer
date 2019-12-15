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
$(document).ready(function() {

    $(".click-title").mouseenter( function(    e){
        e.preventDefault();
        this.style.cursor="pointer";
    });
    $(".click-title").mousedown( function(event){
        event.preventDefault();
    });

    // Ugly code while this script is shared among several pages
    try{
        refreshHitsPerSecond(true);
    } catch(e){}
    try{
        refreshResponseTimeOverTime(true);
    } catch(e){}
    try{
        refreshResponseTimePercentiles();
    } catch(e){}
});


var responseTimePercentilesInfos = {
        data: {"result": {"minY": 279.0, "minX": 0.0, "maxY": 4479.0, "series": [{"data": [[0.0, 279.0], [0.1, 279.0], [0.2, 279.0], [0.3, 279.0], [0.4, 279.0], [0.5, 279.0], [0.6, 729.0], [0.7, 729.0], [0.8, 729.0], [0.9, 729.0], [1.0, 729.0], [1.1, 729.0], [1.2, 747.0], [1.3, 747.0], [1.4, 747.0], [1.5, 747.0], [1.6, 747.0], [1.7, 747.0], [1.8, 747.0], [1.9, 747.0], [2.0, 747.0], [2.1, 747.0], [2.2, 747.0], [2.3, 751.0], [2.4, 751.0], [2.5, 751.0], [2.6, 751.0], [2.7, 751.0], [2.8, 793.0], [2.9, 793.0], [3.0, 793.0], [3.1, 793.0], [3.2, 793.0], [3.3, 793.0], [3.4, 818.0], [3.5, 818.0], [3.6, 818.0], [3.7, 818.0], [3.8, 818.0], [3.9, 854.0], [4.0, 854.0], [4.1, 854.0], [4.2, 854.0], [4.3, 854.0], [4.4, 854.0], [4.5, 866.0], [4.6, 866.0], [4.7, 866.0], [4.8, 866.0], [4.9, 866.0], [5.0, 969.0], [5.1, 969.0], [5.2, 969.0], [5.3, 969.0], [5.4, 969.0], [5.5, 969.0], [5.6, 1000.0], [5.7, 1000.0], [5.8, 1000.0], [5.9, 1000.0], [6.0, 1000.0], [6.1, 1000.0], [6.2, 1029.0], [6.3, 1029.0], [6.4, 1029.0], [6.5, 1029.0], [6.6, 1029.0], [6.7, 1067.0], [6.8, 1067.0], [6.9, 1067.0], [7.0, 1067.0], [7.1, 1067.0], [7.2, 1067.0], [7.3, 1073.0], [7.4, 1073.0], [7.5, 1073.0], [7.6, 1073.0], [7.7, 1073.0], [7.8, 1168.0], [7.9, 1168.0], [8.0, 1168.0], [8.1, 1168.0], [8.2, 1168.0], [8.3, 1168.0], [8.4, 1225.0], [8.5, 1225.0], [8.6, 1225.0], [8.7, 1225.0], [8.8, 1225.0], [8.9, 1277.0], [9.0, 1277.0], [9.1, 1277.0], [9.2, 1277.0], [9.3, 1277.0], [9.4, 1277.0], [9.5, 1324.0], [9.6, 1324.0], [9.7, 1324.0], [9.8, 1324.0], [9.9, 1324.0], [10.0, 1367.0], [10.1, 1367.0], [10.2, 1367.0], [10.3, 1367.0], [10.4, 1367.0], [10.5, 1367.0], [10.6, 1398.0], [10.7, 1398.0], [10.8, 1398.0], [10.9, 1398.0], [11.0, 1398.0], [11.1, 1398.0], [11.2, 1398.0], [11.3, 1398.0], [11.4, 1398.0], [11.5, 1398.0], [11.6, 1398.0], [11.7, 1401.0], [11.8, 1401.0], [11.9, 1401.0], [12.0, 1401.0], [12.1, 1401.0], [12.2, 1401.0], [12.3, 1427.0], [12.4, 1427.0], [12.5, 1427.0], [12.6, 1427.0], [12.7, 1427.0], [12.8, 1429.0], [12.9, 1429.0], [13.0, 1429.0], [13.1, 1429.0], [13.2, 1429.0], [13.3, 1429.0], [13.4, 1430.0], [13.5, 1430.0], [13.6, 1430.0], [13.7, 1430.0], [13.8, 1430.0], [13.9, 1487.0], [14.0, 1487.0], [14.1, 1487.0], [14.2, 1487.0], [14.3, 1487.0], [14.4, 1487.0], [14.5, 1518.0], [14.6, 1518.0], [14.7, 1518.0], [14.8, 1518.0], [14.9, 1518.0], [15.0, 1519.0], [15.1, 1519.0], [15.2, 1519.0], [15.3, 1519.0], [15.4, 1519.0], [15.5, 1519.0], [15.6, 1525.0], [15.7, 1525.0], [15.8, 1525.0], [15.9, 1525.0], [16.0, 1525.0], [16.1, 1525.0], [16.2, 1542.0], [16.3, 1542.0], [16.4, 1542.0], [16.5, 1542.0], [16.6, 1542.0], [16.7, 1566.0], [16.8, 1566.0], [16.9, 1566.0], [17.0, 1566.0], [17.1, 1566.0], [17.2, 1566.0], [17.3, 1580.0], [17.4, 1580.0], [17.5, 1580.0], [17.6, 1580.0], [17.7, 1580.0], [17.8, 1606.0], [17.9, 1606.0], [18.0, 1606.0], [18.1, 1606.0], [18.2, 1606.0], [18.3, 1606.0], [18.4, 1613.0], [18.5, 1613.0], [18.6, 1613.0], [18.7, 1613.0], [18.8, 1613.0], [18.9, 1634.0], [19.0, 1634.0], [19.1, 1634.0], [19.2, 1634.0], [19.3, 1634.0], [19.4, 1634.0], [19.5, 1635.0], [19.6, 1635.0], [19.7, 1635.0], [19.8, 1635.0], [19.9, 1635.0], [20.0, 1635.0], [20.1, 1637.0], [20.2, 1637.0], [20.3, 1637.0], [20.4, 1637.0], [20.5, 1637.0], [20.6, 1643.0], [20.7, 1643.0], [20.8, 1643.0], [20.9, 1643.0], [21.0, 1643.0], [21.1, 1643.0], [21.2, 1648.0], [21.3, 1648.0], [21.4, 1648.0], [21.5, 1648.0], [21.6, 1648.0], [21.7, 1655.0], [21.8, 1655.0], [21.9, 1655.0], [22.0, 1655.0], [22.1, 1655.0], [22.2, 1655.0], [22.3, 1659.0], [22.4, 1659.0], [22.5, 1659.0], [22.6, 1659.0], [22.7, 1659.0], [22.8, 1690.0], [22.9, 1690.0], [23.0, 1690.0], [23.1, 1690.0], [23.2, 1690.0], [23.3, 1690.0], [23.4, 1696.0], [23.5, 1696.0], [23.6, 1696.0], [23.7, 1696.0], [23.8, 1696.0], [23.9, 1758.0], [24.0, 1758.0], [24.1, 1758.0], [24.2, 1758.0], [24.3, 1758.0], [24.4, 1758.0], [24.5, 1768.0], [24.6, 1768.0], [24.7, 1768.0], [24.8, 1768.0], [24.9, 1768.0], [25.0, 1768.0], [25.1, 1781.0], [25.2, 1781.0], [25.3, 1781.0], [25.4, 1781.0], [25.5, 1781.0], [25.6, 1786.0], [25.7, 1786.0], [25.8, 1786.0], [25.9, 1786.0], [26.0, 1786.0], [26.1, 1786.0], [26.2, 1803.0], [26.3, 1803.0], [26.4, 1803.0], [26.5, 1803.0], [26.6, 1803.0], [26.7, 1806.0], [26.8, 1806.0], [26.9, 1806.0], [27.0, 1806.0], [27.1, 1806.0], [27.2, 1806.0], [27.3, 1814.0], [27.4, 1814.0], [27.5, 1814.0], [27.6, 1814.0], [27.7, 1814.0], [27.8, 1832.0], [27.9, 1832.0], [28.0, 1832.0], [28.1, 1832.0], [28.2, 1832.0], [28.3, 1832.0], [28.4, 1840.0], [28.5, 1840.0], [28.6, 1840.0], [28.7, 1840.0], [28.8, 1840.0], [28.9, 1851.0], [29.0, 1851.0], [29.1, 1851.0], [29.2, 1851.0], [29.3, 1851.0], [29.4, 1851.0], [29.5, 1853.0], [29.6, 1853.0], [29.7, 1853.0], [29.8, 1853.0], [29.9, 1853.0], [30.0, 1853.0], [30.1, 1856.0], [30.2, 1856.0], [30.3, 1856.0], [30.4, 1856.0], [30.5, 1856.0], [30.6, 1860.0], [30.7, 1860.0], [30.8, 1860.0], [30.9, 1860.0], [31.0, 1860.0], [31.1, 1860.0], [31.2, 1860.0], [31.3, 1860.0], [31.4, 1860.0], [31.5, 1860.0], [31.6, 1860.0], [31.7, 1871.0], [31.8, 1871.0], [31.9, 1871.0], [32.0, 1871.0], [32.1, 1871.0], [32.2, 1871.0], [32.3, 1875.0], [32.4, 1875.0], [32.5, 1875.0], [32.6, 1875.0], [32.7, 1875.0], [32.8, 1878.0], [32.9, 1878.0], [33.0, 1878.0], [33.1, 1878.0], [33.2, 1878.0], [33.3, 1878.0], [33.4, 1908.0], [33.5, 1908.0], [33.6, 1908.0], [33.7, 1908.0], [33.8, 1908.0], [33.9, 1941.0], [34.0, 1941.0], [34.1, 1941.0], [34.2, 1941.0], [34.3, 1941.0], [34.4, 1941.0], [34.5, 1962.0], [34.6, 1962.0], [34.7, 1962.0], [34.8, 1962.0], [34.9, 1962.0], [35.0, 1962.0], [35.1, 1967.0], [35.2, 1967.0], [35.3, 1967.0], [35.4, 1967.0], [35.5, 1967.0], [35.6, 1969.0], [35.7, 1969.0], [35.8, 1969.0], [35.9, 1969.0], [36.0, 1969.0], [36.1, 1969.0], [36.2, 1969.0], [36.3, 1969.0], [36.4, 1969.0], [36.5, 1969.0], [36.6, 1969.0], [36.7, 1975.0], [36.8, 1975.0], [36.9, 1975.0], [37.0, 1975.0], [37.1, 1975.0], [37.2, 1975.0], [37.3, 1988.0], [37.4, 1988.0], [37.5, 1988.0], [37.6, 1988.0], [37.7, 1988.0], [37.8, 1991.0], [37.9, 1991.0], [38.0, 1991.0], [38.1, 1991.0], [38.2, 1991.0], [38.3, 1991.0], [38.4, 2017.0], [38.5, 2017.0], [38.6, 2017.0], [38.7, 2017.0], [38.8, 2017.0], [38.9, 2020.0], [39.0, 2020.0], [39.1, 2020.0], [39.2, 2020.0], [39.3, 2020.0], [39.4, 2020.0], [39.5, 2040.0], [39.6, 2040.0], [39.7, 2040.0], [39.8, 2040.0], [39.9, 2040.0], [40.0, 2040.0], [40.1, 2041.0], [40.2, 2041.0], [40.3, 2041.0], [40.4, 2041.0], [40.5, 2041.0], [40.6, 2042.0], [40.7, 2042.0], [40.8, 2042.0], [40.9, 2042.0], [41.0, 2042.0], [41.1, 2042.0], [41.2, 2058.0], [41.3, 2058.0], [41.4, 2058.0], [41.5, 2058.0], [41.6, 2058.0], [41.7, 2072.0], [41.8, 2072.0], [41.9, 2072.0], [42.0, 2072.0], [42.1, 2072.0], [42.2, 2072.0], [42.3, 2081.0], [42.4, 2081.0], [42.5, 2081.0], [42.6, 2081.0], [42.7, 2081.0], [42.8, 2100.0], [42.9, 2100.0], [43.0, 2100.0], [43.1, 2100.0], [43.2, 2100.0], [43.3, 2100.0], [43.4, 2105.0], [43.5, 2105.0], [43.6, 2105.0], [43.7, 2105.0], [43.8, 2105.0], [43.9, 2111.0], [44.0, 2111.0], [44.1, 2111.0], [44.2, 2111.0], [44.3, 2111.0], [44.4, 2111.0], [44.5, 2112.0], [44.6, 2112.0], [44.7, 2112.0], [44.8, 2112.0], [44.9, 2112.0], [45.0, 2112.0], [45.1, 2115.0], [45.2, 2115.0], [45.3, 2115.0], [45.4, 2115.0], [45.5, 2115.0], [45.6, 2122.0], [45.7, 2122.0], [45.8, 2122.0], [45.9, 2122.0], [46.0, 2122.0], [46.1, 2122.0], [46.2, 2126.0], [46.3, 2126.0], [46.4, 2126.0], [46.5, 2126.0], [46.6, 2126.0], [46.7, 2128.0], [46.8, 2128.0], [46.9, 2128.0], [47.0, 2128.0], [47.1, 2128.0], [47.2, 2128.0], [47.3, 2134.0], [47.4, 2134.0], [47.5, 2134.0], [47.6, 2134.0], [47.7, 2134.0], [47.8, 2141.0], [47.9, 2141.0], [48.0, 2141.0], [48.1, 2141.0], [48.2, 2141.0], [48.3, 2141.0], [48.4, 2157.0], [48.5, 2157.0], [48.6, 2157.0], [48.7, 2157.0], [48.8, 2157.0], [48.9, 2158.0], [49.0, 2158.0], [49.1, 2158.0], [49.2, 2158.0], [49.3, 2158.0], [49.4, 2158.0], [49.5, 2159.0], [49.6, 2159.0], [49.7, 2159.0], [49.8, 2159.0], [49.9, 2159.0], [50.0, 2159.0], [50.1, 2165.0], [50.2, 2165.0], [50.3, 2165.0], [50.4, 2165.0], [50.5, 2165.0], [50.6, 2202.0], [50.7, 2202.0], [50.8, 2202.0], [50.9, 2202.0], [51.0, 2202.0], [51.1, 2202.0], [51.2, 2205.0], [51.3, 2205.0], [51.4, 2205.0], [51.5, 2205.0], [51.6, 2205.0], [51.7, 2213.0], [51.8, 2213.0], [51.9, 2213.0], [52.0, 2213.0], [52.1, 2213.0], [52.2, 2213.0], [52.3, 2223.0], [52.4, 2223.0], [52.5, 2223.0], [52.6, 2223.0], [52.7, 2223.0], [52.8, 2224.0], [52.9, 2224.0], [53.0, 2224.0], [53.1, 2224.0], [53.2, 2224.0], [53.3, 2224.0], [53.4, 2243.0], [53.5, 2243.0], [53.6, 2243.0], [53.7, 2243.0], [53.8, 2243.0], [53.9, 2250.0], [54.0, 2250.0], [54.1, 2250.0], [54.2, 2250.0], [54.3, 2250.0], [54.4, 2250.0], [54.5, 2260.0], [54.6, 2260.0], [54.7, 2260.0], [54.8, 2260.0], [54.9, 2260.0], [55.0, 2260.0], [55.1, 2268.0], [55.2, 2268.0], [55.3, 2268.0], [55.4, 2268.0], [55.5, 2268.0], [55.6, 2271.0], [55.7, 2271.0], [55.8, 2271.0], [55.9, 2271.0], [56.0, 2271.0], [56.1, 2271.0], [56.2, 2282.0], [56.3, 2282.0], [56.4, 2282.0], [56.5, 2282.0], [56.6, 2282.0], [56.7, 2283.0], [56.8, 2283.0], [56.9, 2283.0], [57.0, 2283.0], [57.1, 2283.0], [57.2, 2283.0], [57.3, 2292.0], [57.4, 2292.0], [57.5, 2292.0], [57.6, 2292.0], [57.7, 2292.0], [57.8, 2298.0], [57.9, 2298.0], [58.0, 2298.0], [58.1, 2298.0], [58.2, 2298.0], [58.3, 2298.0], [58.4, 2300.0], [58.5, 2300.0], [58.6, 2300.0], [58.7, 2300.0], [58.8, 2300.0], [58.9, 2309.0], [59.0, 2309.0], [59.1, 2309.0], [59.2, 2309.0], [59.3, 2309.0], [59.4, 2309.0], [59.5, 2311.0], [59.6, 2311.0], [59.7, 2311.0], [59.8, 2311.0], [59.9, 2311.0], [60.0, 2311.0], [60.1, 2320.0], [60.2, 2320.0], [60.3, 2320.0], [60.4, 2320.0], [60.5, 2320.0], [60.6, 2323.0], [60.7, 2323.0], [60.8, 2323.0], [60.9, 2323.0], [61.0, 2323.0], [61.1, 2323.0], [61.2, 2328.0], [61.3, 2328.0], [61.4, 2328.0], [61.5, 2328.0], [61.6, 2328.0], [61.7, 2345.0], [61.8, 2345.0], [61.9, 2345.0], [62.0, 2345.0], [62.1, 2345.0], [62.2, 2345.0], [62.3, 2349.0], [62.4, 2349.0], [62.5, 2349.0], [62.6, 2349.0], [62.7, 2349.0], [62.8, 2361.0], [62.9, 2361.0], [63.0, 2361.0], [63.1, 2361.0], [63.2, 2361.0], [63.3, 2361.0], [63.4, 2362.0], [63.5, 2362.0], [63.6, 2362.0], [63.7, 2362.0], [63.8, 2362.0], [63.9, 2362.0], [64.0, 2362.0], [64.1, 2362.0], [64.2, 2362.0], [64.3, 2362.0], [64.4, 2362.0], [64.5, 2363.0], [64.6, 2363.0], [64.7, 2363.0], [64.8, 2363.0], [64.9, 2363.0], [65.0, 2363.0], [65.1, 2373.0], [65.2, 2373.0], [65.3, 2373.0], [65.4, 2373.0], [65.5, 2373.0], [65.6, 2387.0], [65.7, 2387.0], [65.8, 2387.0], [65.9, 2387.0], [66.0, 2387.0], [66.1, 2387.0], [66.2, 2393.0], [66.3, 2393.0], [66.4, 2393.0], [66.5, 2393.0], [66.6, 2393.0], [66.7, 2405.0], [66.8, 2405.0], [66.9, 2405.0], [67.0, 2405.0], [67.1, 2405.0], [67.2, 2405.0], [67.3, 2435.0], [67.4, 2435.0], [67.5, 2435.0], [67.6, 2435.0], [67.7, 2435.0], [67.8, 2450.0], [67.9, 2450.0], [68.0, 2450.0], [68.1, 2450.0], [68.2, 2450.0], [68.3, 2450.0], [68.4, 2456.0], [68.5, 2456.0], [68.6, 2456.0], [68.7, 2456.0], [68.8, 2456.0], [68.9, 2459.0], [69.0, 2459.0], [69.1, 2459.0], [69.2, 2459.0], [69.3, 2459.0], [69.4, 2459.0], [69.5, 2482.0], [69.6, 2482.0], [69.7, 2482.0], [69.8, 2482.0], [69.9, 2482.0], [70.0, 2482.0], [70.1, 2505.0], [70.2, 2505.0], [70.3, 2505.0], [70.4, 2505.0], [70.5, 2505.0], [70.6, 2514.0], [70.7, 2514.0], [70.8, 2514.0], [70.9, 2514.0], [71.0, 2514.0], [71.1, 2514.0], [71.2, 2536.0], [71.3, 2536.0], [71.4, 2536.0], [71.5, 2536.0], [71.6, 2536.0], [71.7, 2557.0], [71.8, 2557.0], [71.9, 2557.0], [72.0, 2557.0], [72.1, 2557.0], [72.2, 2557.0], [72.3, 2562.0], [72.4, 2562.0], [72.5, 2562.0], [72.6, 2562.0], [72.7, 2562.0], [72.8, 2651.0], [72.9, 2651.0], [73.0, 2651.0], [73.1, 2651.0], [73.2, 2651.0], [73.3, 2651.0], [73.4, 2652.0], [73.5, 2652.0], [73.6, 2652.0], [73.7, 2652.0], [73.8, 2652.0], [73.9, 2679.0], [74.0, 2679.0], [74.1, 2679.0], [74.2, 2679.0], [74.3, 2679.0], [74.4, 2679.0], [74.5, 2771.0], [74.6, 2771.0], [74.7, 2771.0], [74.8, 2771.0], [74.9, 2771.0], [75.0, 2771.0], [75.1, 2798.0], [75.2, 2798.0], [75.3, 2798.0], [75.4, 2798.0], [75.5, 2798.0], [75.6, 2798.0], [75.7, 2798.0], [75.8, 2798.0], [75.9, 2798.0], [76.0, 2798.0], [76.1, 2798.0], [76.2, 2828.0], [76.3, 2828.0], [76.4, 2828.0], [76.5, 2828.0], [76.6, 2828.0], [76.7, 2861.0], [76.8, 2861.0], [76.9, 2861.0], [77.0, 2861.0], [77.1, 2861.0], [77.2, 2861.0], [77.3, 2887.0], [77.4, 2887.0], [77.5, 2887.0], [77.6, 2887.0], [77.7, 2887.0], [77.8, 2903.0], [77.9, 2903.0], [78.0, 2903.0], [78.1, 2903.0], [78.2, 2903.0], [78.3, 2903.0], [78.4, 2905.0], [78.5, 2905.0], [78.6, 2905.0], [78.7, 2905.0], [78.8, 2905.0], [78.9, 2913.0], [79.0, 2913.0], [79.1, 2913.0], [79.2, 2913.0], [79.3, 2913.0], [79.4, 2913.0], [79.5, 2939.0], [79.6, 2939.0], [79.7, 2939.0], [79.8, 2939.0], [79.9, 2939.0], [80.0, 2939.0], [80.1, 2967.0], [80.2, 2967.0], [80.3, 2967.0], [80.4, 2967.0], [80.5, 2967.0], [80.6, 2967.0], [80.7, 2967.0], [80.8, 2967.0], [80.9, 2967.0], [81.0, 2967.0], [81.1, 2967.0], [81.2, 2979.0], [81.3, 2979.0], [81.4, 2979.0], [81.5, 2979.0], [81.6, 2979.0], [81.7, 2982.0], [81.8, 2982.0], [81.9, 2982.0], [82.0, 2982.0], [82.1, 2982.0], [82.2, 2982.0], [82.3, 3006.0], [82.4, 3006.0], [82.5, 3006.0], [82.6, 3006.0], [82.7, 3006.0], [82.8, 3011.0], [82.9, 3011.0], [83.0, 3011.0], [83.1, 3011.0], [83.2, 3011.0], [83.3, 3011.0], [83.4, 3014.0], [83.5, 3014.0], [83.6, 3014.0], [83.7, 3014.0], [83.8, 3014.0], [83.9, 3089.0], [84.0, 3089.0], [84.1, 3089.0], [84.2, 3089.0], [84.3, 3089.0], [84.4, 3089.0], [84.5, 3202.0], [84.6, 3202.0], [84.7, 3202.0], [84.8, 3202.0], [84.9, 3202.0], [85.0, 3202.0], [85.1, 3209.0], [85.2, 3209.0], [85.3, 3209.0], [85.4, 3209.0], [85.5, 3209.0], [85.6, 3212.0], [85.7, 3212.0], [85.8, 3212.0], [85.9, 3212.0], [86.0, 3212.0], [86.1, 3212.0], [86.2, 3228.0], [86.3, 3228.0], [86.4, 3228.0], [86.5, 3228.0], [86.6, 3228.0], [86.7, 3229.0], [86.8, 3229.0], [86.9, 3229.0], [87.0, 3229.0], [87.1, 3229.0], [87.2, 3229.0], [87.3, 3233.0], [87.4, 3233.0], [87.5, 3233.0], [87.6, 3233.0], [87.7, 3233.0], [87.8, 3279.0], [87.9, 3279.0], [88.0, 3279.0], [88.1, 3279.0], [88.2, 3279.0], [88.3, 3279.0], [88.4, 3297.0], [88.5, 3297.0], [88.6, 3297.0], [88.7, 3297.0], [88.8, 3297.0], [88.9, 3333.0], [89.0, 3333.0], [89.1, 3333.0], [89.2, 3333.0], [89.3, 3333.0], [89.4, 3333.0], [89.5, 3379.0], [89.6, 3379.0], [89.7, 3379.0], [89.8, 3379.0], [89.9, 3379.0], [90.0, 3379.0], [90.1, 3458.0], [90.2, 3458.0], [90.3, 3458.0], [90.4, 3458.0], [90.5, 3458.0], [90.6, 3539.0], [90.7, 3539.0], [90.8, 3539.0], [90.9, 3539.0], [91.0, 3539.0], [91.1, 3539.0], [91.2, 3558.0], [91.3, 3558.0], [91.4, 3558.0], [91.5, 3558.0], [91.6, 3558.0], [91.7, 3661.0], [91.8, 3661.0], [91.9, 3661.0], [92.0, 3661.0], [92.1, 3661.0], [92.2, 3661.0], [92.3, 4010.0], [92.4, 4010.0], [92.5, 4010.0], [92.6, 4010.0], [92.7, 4010.0], [92.8, 4136.0], [92.9, 4136.0], [93.0, 4136.0], [93.1, 4136.0], [93.2, 4136.0], [93.3, 4136.0], [93.4, 4147.0], [93.5, 4147.0], [93.6, 4147.0], [93.7, 4147.0], [93.8, 4147.0], [93.9, 4195.0], [94.0, 4195.0], [94.1, 4195.0], [94.2, 4195.0], [94.3, 4195.0], [94.4, 4195.0], [94.5, 4226.0], [94.6, 4226.0], [94.7, 4226.0], [94.8, 4226.0], [94.9, 4226.0], [95.0, 4226.0], [95.1, 4293.0], [95.2, 4293.0], [95.3, 4293.0], [95.4, 4293.0], [95.5, 4293.0], [95.6, 4298.0], [95.7, 4298.0], [95.8, 4298.0], [95.9, 4298.0], [96.0, 4298.0], [96.1, 4298.0], [96.2, 4337.0], [96.3, 4337.0], [96.4, 4337.0], [96.5, 4337.0], [96.6, 4337.0], [96.7, 4340.0], [96.8, 4340.0], [96.9, 4340.0], [97.0, 4340.0], [97.1, 4340.0], [97.2, 4340.0], [97.3, 4362.0], [97.4, 4362.0], [97.5, 4362.0], [97.6, 4362.0], [97.7, 4362.0], [97.8, 4368.0], [97.9, 4368.0], [98.0, 4368.0], [98.1, 4368.0], [98.2, 4368.0], [98.3, 4368.0], [98.4, 4394.0], [98.5, 4394.0], [98.6, 4394.0], [98.7, 4394.0], [98.8, 4394.0], [98.9, 4467.0], [99.0, 4467.0], [99.1, 4467.0], [99.2, 4467.0], [99.3, 4467.0], [99.4, 4467.0], [99.5, 4479.0], [99.6, 4479.0], [99.7, 4479.0], [99.8, 4479.0], [99.9, 4479.0], [100.0, 4479.0]], "isOverall": false, "label": "HTTP Request", "isController": false}], "supportsControllersDiscrimination": true, "maxX": 100.0, "title": "Response Time Percentiles"}},
        getOptions: function() {
            return {
                series: {
                    points: { show: false }
                },
                legend: {
                    noColumns: 2,
                    show: true,
                    container: '#legendResponseTimePercentiles'
                },
                xaxis: {
                    tickDecimals: 1,
                    axisLabel: "Percentiles",
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                yaxis: {
                    axisLabel: "Percentile value in ms",
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20
                },
                grid: {
                    hoverable: true // IMPORTANT! this is needed for tooltip to
                                    // work
                },
                tooltip: true,
                tooltipOpts: {
                    content: "%s : %x.2 percentile was %y ms"
                },
                selection: { mode: "xy" },
            };
        },
        createGraph: function() {
            var data = this.data;
            var dataset = prepareData(data.result.series, $("#choicesResponseTimePercentiles"));
            var options = this.getOptions();
            prepareOptions(options, data);
            $.plot($("#flotResponseTimesPercentiles"), dataset, options);
            // setup overview
            $.plot($("#overviewResponseTimesPercentiles"), dataset, prepareOverviewOptions(options));
        }
};

/**
 * @param elementId Id of element where we display message
 */
function setEmptyGraph(elementId) {
    $(function() {
        $(elementId).text("No graph series with filter="+seriesFilter);
    });
}

// Response times percentiles
function refreshResponseTimePercentiles() {
    var infos = responseTimePercentilesInfos;
    prepareSeries(infos.data);
    if(infos.data.result.series.length == 0) {
        setEmptyGraph("#bodyResponseTimePercentiles");
        return;
    }
    if (isGraph($("#flotResponseTimesPercentiles"))){
        infos.createGraph();
    } else {
        var choiceContainer = $("#choicesResponseTimePercentiles");
        createLegend(choiceContainer, infos);
        infos.createGraph();
        setGraphZoomable("#flotResponseTimesPercentiles", "#overviewResponseTimesPercentiles");
        $('#bodyResponseTimePercentiles .legendColorBox > div').each(function(i){
            $(this).clone().prependTo(choiceContainer.find("li").eq(i));
        });
    }
}

var responseTimeDistributionInfos = {
        data: {"result": {"minY": 1.0, "minX": 200.0, "maxY": 15.0, "series": [{"data": [[700.0, 5.0], [800.0, 3.0], [900.0, 1.0], [1000.0, 4.0], [1100.0, 1.0], [1200.0, 2.0], [1300.0, 4.0], [1400.0, 5.0], [1500.0, 6.0], [1600.0, 11.0], [1700.0, 4.0], [1800.0, 13.0], [1900.0, 9.0], [2000.0, 8.0], [2100.0, 14.0], [2200.0, 14.0], [2300.0, 15.0], [2400.0, 6.0], [2500.0, 5.0], [2600.0, 3.0], [2700.0, 3.0], [2800.0, 3.0], [2900.0, 8.0], [3000.0, 4.0], [3200.0, 8.0], [3300.0, 2.0], [200.0, 1.0], [3400.0, 1.0], [3500.0, 2.0], [3600.0, 1.0], [4000.0, 1.0], [4100.0, 3.0], [4300.0, 5.0], [4200.0, 3.0], [4400.0, 2.0]], "isOverall": false, "label": "HTTP Request", "isController": false}], "supportsControllersDiscrimination": true, "granularity": 100, "maxX": 4400.0, "title": "Response Time Distribution"}},
        getOptions: function() {
            var granularity = this.data.result.granularity;
            return {
                legend: {
                    noColumns: 2,
                    show: true,
                    container: '#legendResponseTimeDistribution'
                },
                xaxis:{
                    axisLabel: "Response times in ms",
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                yaxis: {
                    axisLabel: "Number of responses",
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                bars : {
                    show: true,
                    barWidth: this.data.result.granularity
                },
                grid: {
                    hoverable: true // IMPORTANT! this is needed for tooltip to
                                    // work
                },
                tooltip: true,
                tooltipOpts: {
                    content: function(label, xval, yval, flotItem){
                        return yval + " responses for " + label + " were between " + xval + " and " + (xval + granularity) + " ms";
                    }
                }
            };
        },
        createGraph: function() {
            var data = this.data;
            var options = this.getOptions();
            prepareOptions(options, data);
            $.plot($("#flotResponseTimeDistribution"), prepareData(data.result.series, $("#choicesResponseTimeDistribution")), options);
        }

};

// Response time distribution
function refreshResponseTimeDistribution() {
    var infos = responseTimeDistributionInfos;
    prepareSeries(infos.data);
    if(infos.data.result.series.length == 0) {
        setEmptyGraph("#bodyResponseTimeDistribution");
        return;
    }
    if (isGraph($("#flotResponseTimeDistribution"))){
        infos.createGraph();
    }else{
        var choiceContainer = $("#choicesResponseTimeDistribution");
        createLegend(choiceContainer, infos);
        infos.createGraph();
        $('#footerResponseTimeDistribution .legendColorBox > div').each(function(i){
            $(this).clone().prependTo(choiceContainer.find("li").eq(i));
        });
    }
};


var syntheticResponseTimeDistributionInfos = {
        data: {"result": {"minY": 1.0, "minX": 0.0, "ticks": [[0, "Requests having \nresponse time <= 500ms"], [1, "Requests having \nresponse time > 500ms and <= 1\u00A0500ms"], [2, "Requests having \nresponse time > 1\u00A0500ms"], [3, "Requests in error"]], "maxY": 149.0, "series": [{"data": [[0.0, 1.0]], "color": "#9ACD32", "isOverall": false, "label": "Requests having \nresponse time <= 500ms", "isController": false}, {"data": [[1.0, 18.0]], "color": "yellow", "isOverall": false, "label": "Requests having \nresponse time > 500ms and <= 1\u00A0500ms", "isController": false}, {"data": [[2.0, 149.0]], "color": "orange", "isOverall": false, "label": "Requests having \nresponse time > 1\u00A0500ms", "isController": false}, {"data": [[3.0, 12.0]], "color": "#FF6347", "isOverall": false, "label": "Requests in error", "isController": false}], "supportsControllersDiscrimination": false, "maxX": 3.0, "title": "Synthetic Response Times Distribution"}},
        getOptions: function() {
            return {
                legend: {
                    noColumns: 2,
                    show: true,
                    container: '#legendSyntheticResponseTimeDistribution'
                },
                xaxis:{
                    axisLabel: "Response times ranges",
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                    tickLength:0,
                    min:-0.5,
                    max:3.5
                },
                yaxis: {
                    axisLabel: "Number of responses",
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                bars : {
                    show: true,
                    align: "center",
                    barWidth: 0.25,
                    fill:.75
                },
                grid: {
                    hoverable: true // IMPORTANT! this is needed for tooltip to
                                    // work
                },
                tooltip: true,
                tooltipOpts: {
                    content: function(label, xval, yval, flotItem){
                        return yval + " " + label;
                    }
                }
            };
        },
        createGraph: function() {
            var data = this.data;
            var options = this.getOptions();
            prepareOptions(options, data);
            options.xaxis.ticks = data.result.ticks;
            $.plot($("#flotSyntheticResponseTimeDistribution"), prepareData(data.result.series, $("#choicesSyntheticResponseTimeDistribution")), options);
        }

};

// Response time distribution
function refreshSyntheticResponseTimeDistribution() {
    var infos = syntheticResponseTimeDistributionInfos;
    prepareSeries(infos.data, true);
    if (isGraph($("#flotSyntheticResponseTimeDistribution"))){
        infos.createGraph();
    }else{
        var choiceContainer = $("#choicesSyntheticResponseTimeDistribution");
        createLegend(choiceContainer, infos);
        infos.createGraph();
        $('#footerSyntheticResponseTimeDistribution .legendColorBox > div').each(function(i){
            $(this).clone().prependTo(choiceContainer.find("li").eq(i));
        });
    }
};

var activeThreadsOverTimeInfos = {
        data: {"result": {"minY": 26.777777777777775, "minX": 1.57623774E12, "maxY": 26.777777777777775, "series": [{"data": [[1.57623774E12, 26.777777777777775]], "isOverall": false, "label": "Children", "isController": false}], "supportsControllersDiscrimination": false, "granularity": 60000, "maxX": 1.57623774E12, "title": "Active Threads Over Time"}},
        getOptions: function() {
            return {
                series: {
                    stack: true,
                    lines: {
                        show: true,
                        fill: true
                    },
                    points: {
                        show: true
                    }
                },
                xaxis: {
                    mode: "time",
                    timeformat: getTimeFormat(this.data.result.granularity),
                    axisLabel: getElapsedTimeLabel(this.data.result.granularity),
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                yaxis: {
                    axisLabel: "Number of active threads",
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20
                },
                legend: {
                    noColumns: 6,
                    show: true,
                    container: '#legendActiveThreadsOverTime'
                },
                grid: {
                    hoverable: true // IMPORTANT! this is needed for tooltip to
                                    // work
                },
                selection: {
                    mode: 'xy'
                },
                tooltip: true,
                tooltipOpts: {
                    content: "%s : At %x there were %y active threads"
                }
            };
        },
        createGraph: function() {
            var data = this.data;
            var dataset = prepareData(data.result.series, $("#choicesActiveThreadsOverTime"));
            var options = this.getOptions();
            prepareOptions(options, data);
            $.plot($("#flotActiveThreadsOverTime"), dataset, options);
            // setup overview
            $.plot($("#overviewActiveThreadsOverTime"), dataset, prepareOverviewOptions(options));
        }
};

// Active Threads Over Time
function refreshActiveThreadsOverTime(fixTimestamps) {
    var infos = activeThreadsOverTimeInfos;
    prepareSeries(infos.data);
    if(fixTimestamps) {
        fixTimeStamps(infos.data.result.series, 10800000);
    }
    if(isGraph($("#flotActiveThreadsOverTime"))) {
        infos.createGraph();
    }else{
        var choiceContainer = $("#choicesActiveThreadsOverTime");
        createLegend(choiceContainer, infos);
        infos.createGraph();
        setGraphZoomable("#flotActiveThreadsOverTime", "#overviewActiveThreadsOverTime");
        $('#footerActiveThreadsOverTime .legendColorBox > div').each(function(i){
            $(this).clone().prependTo(choiceContainer.find("li").eq(i));
        });
    }
};

var timeVsThreadsInfos = {
        data: {"result": {"minY": 673.0, "minX": 1.0, "maxY": 3297.0, "series": [{"data": [[2.0, 1000.0], [3.0, 1324.0], [4.0, 1029.0], [5.0, 2362.0], [6.0, 2320.0], [7.0, 2652.0], [8.0, 2362.0], [9.0, 2939.0], [10.0, 3089.0], [11.0, 2202.0], [12.0, 1941.0], [13.0, 1969.0], [14.0, 2679.0], [15.0, 3297.0], [16.0, 2482.0], [1.0, 673.0], [17.0, 2387.0], [18.0, 3011.0], [19.0, 3197.75], [20.0, 3202.0], [21.0, 2557.0], [22.0, 2708.5], [23.0, 2365.5], [24.0, 2343.5], [25.0, 2268.0], [26.0, 2088.0], [27.0, 2144.666666666667], [28.0, 2090.0], [29.0, 2298.0], [30.0, 2277.9]], "isOverall": false, "label": "HTTP Request", "isController": false}, {"data": [[26.777777777777775, 2288.4166666666674]], "isOverall": false, "label": "HTTP Request-Aggregated", "isController": false}], "supportsControllersDiscrimination": true, "maxX": 30.0, "title": "Time VS Threads"}},
        getOptions: function() {
            return {
                series: {
                    lines: {
                        show: true
                    },
                    points: {
                        show: true
                    }
                },
                xaxis: {
                    axisLabel: "Number of active threads",
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                yaxis: {
                    axisLabel: "Average response times in ms",
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20
                },
                legend: { noColumns: 2,show: true, container: '#legendTimeVsThreads' },
                selection: {
                    mode: 'xy'
                },
                grid: {
                    hoverable: true // IMPORTANT! this is needed for tooltip to work
                },
                tooltip: true,
                tooltipOpts: {
                    content: "%s: At %x.2 active threads, Average response time was %y.2 ms"
                }
            };
        },
        createGraph: function() {
            var data = this.data;
            var dataset = prepareData(data.result.series, $("#choicesTimeVsThreads"));
            var options = this.getOptions();
            prepareOptions(options, data);
            $.plot($("#flotTimesVsThreads"), dataset, options);
            // setup overview
            $.plot($("#overviewTimesVsThreads"), dataset, prepareOverviewOptions(options));
        }
};

// Time vs threads
function refreshTimeVsThreads(){
    var infos = timeVsThreadsInfos;
    prepareSeries(infos.data);
    if(infos.data.result.series.length == 0) {
        setEmptyGraph("#bodyTimeVsThreads");
        return;
    }
    if(isGraph($("#flotTimesVsThreads"))){
        infos.createGraph();
    }else{
        var choiceContainer = $("#choicesTimeVsThreads");
        createLegend(choiceContainer, infos);
        infos.createGraph();
        setGraphZoomable("#flotTimesVsThreads", "#overviewTimesVsThreads");
        $('#footerTimeVsThreads .legendColorBox > div').each(function(i){
            $(this).clone().prependTo(choiceContainer.find("li").eq(i));
        });
    }
};

var bytesThroughputOverTimeInfos = {
        data : {"result": {"minY": 528.0, "minX": 1.57623774E12, "maxY": 90857.26666666666, "series": [{"data": [[1.57623774E12, 90857.26666666666]], "isOverall": false, "label": "Bytes received per second", "isController": false}, {"data": [[1.57623774E12, 528.0]], "isOverall": false, "label": "Bytes sent per second", "isController": false}], "supportsControllersDiscrimination": false, "granularity": 60000, "maxX": 1.57623774E12, "title": "Bytes Throughput Over Time"}},
        getOptions : function(){
            return {
                series: {
                    lines: {
                        show: true
                    },
                    points: {
                        show: true
                    }
                },
                xaxis: {
                    mode: "time",
                    timeformat: getTimeFormat(this.data.result.granularity),
                    axisLabel: getElapsedTimeLabel(this.data.result.granularity) ,
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                yaxis: {
                    axisLabel: "Bytes / sec",
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                legend: {
                    noColumns: 2,
                    show: true,
                    container: '#legendBytesThroughputOverTime'
                },
                selection: {
                    mode: "xy"
                },
                grid: {
                    hoverable: true // IMPORTANT! this is needed for tooltip to
                                    // work
                },
                tooltip: true,
                tooltipOpts: {
                    content: "%s at %x was %y"
                }
            };
        },
        createGraph : function() {
            var data = this.data;
            var dataset = prepareData(data.result.series, $("#choicesBytesThroughputOverTime"));
            var options = this.getOptions();
            prepareOptions(options, data);
            $.plot($("#flotBytesThroughputOverTime"), dataset, options);
            // setup overview
            $.plot($("#overviewBytesThroughputOverTime"), dataset, prepareOverviewOptions(options));
        }
};

// Bytes throughput Over Time
function refreshBytesThroughputOverTime(fixTimestamps) {
    var infos = bytesThroughputOverTimeInfos;
    prepareSeries(infos.data);
    if(fixTimestamps) {
        fixTimeStamps(infos.data.result.series, 10800000);
    }
    if(isGraph($("#flotBytesThroughputOverTime"))){
        infos.createGraph();
    }else{
        var choiceContainer = $("#choicesBytesThroughputOverTime");
        createLegend(choiceContainer, infos);
        infos.createGraph();
        setGraphZoomable("#flotBytesThroughputOverTime", "#overviewBytesThroughputOverTime");
        $('#footerBytesThroughputOverTime .legendColorBox > div').each(function(i){
            $(this).clone().prependTo(choiceContainer.find("li").eq(i));
        });
    }
}

var responseTimesOverTimeInfos = {
        data: {"result": {"minY": 2288.4166666666674, "minX": 1.57623774E12, "maxY": 2288.4166666666674, "series": [{"data": [[1.57623774E12, 2288.4166666666674]], "isOverall": false, "label": "HTTP Request", "isController": false}], "supportsControllersDiscrimination": true, "granularity": 60000, "maxX": 1.57623774E12, "title": "Response Time Over Time"}},
        getOptions: function(){
            return {
                series: {
                    lines: {
                        show: true
                    },
                    points: {
                        show: true
                    }
                },
                xaxis: {
                    mode: "time",
                    timeformat: getTimeFormat(this.data.result.granularity),
                    axisLabel: getElapsedTimeLabel(this.data.result.granularity),
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                yaxis: {
                    axisLabel: "Average response time in ms",
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                legend: {
                    noColumns: 2,
                    show: true,
                    container: '#legendResponseTimesOverTime'
                },
                selection: {
                    mode: 'xy'
                },
                grid: {
                    hoverable: true // IMPORTANT! this is needed for tooltip to
                                    // work
                },
                tooltip: true,
                tooltipOpts: {
                    content: "%s : at %x Average response time was %y ms"
                }
            };
        },
        createGraph: function() {
            var data = this.data;
            var dataset = prepareData(data.result.series, $("#choicesResponseTimesOverTime"));
            var options = this.getOptions();
            prepareOptions(options, data);
            $.plot($("#flotResponseTimesOverTime"), dataset, options);
            // setup overview
            $.plot($("#overviewResponseTimesOverTime"), dataset, prepareOverviewOptions(options));
        }
};

// Response Times Over Time
function refreshResponseTimeOverTime(fixTimestamps) {
    var infos = responseTimesOverTimeInfos;
    prepareSeries(infos.data);
    if(infos.data.result.series.length == 0) {
        setEmptyGraph("#bodyResponseTimeOverTime");
        return;
    }
    if(fixTimestamps) {
        fixTimeStamps(infos.data.result.series, 10800000);
    }
    if(isGraph($("#flotResponseTimesOverTime"))){
        infos.createGraph();
    }else{
        var choiceContainer = $("#choicesResponseTimesOverTime");
        createLegend(choiceContainer, infos);
        infos.createGraph();
        setGraphZoomable("#flotResponseTimesOverTime", "#overviewResponseTimesOverTime");
        $('#footerResponseTimesOverTime .legendColorBox > div').each(function(i){
            $(this).clone().prependTo(choiceContainer.find("li").eq(i));
        });
    }
};

var latenciesOverTimeInfos = {
        data: {"result": {"minY": 2244.688888888888, "minX": 1.57623774E12, "maxY": 2244.688888888888, "series": [{"data": [[1.57623774E12, 2244.688888888888]], "isOverall": false, "label": "HTTP Request", "isController": false}], "supportsControllersDiscrimination": true, "granularity": 60000, "maxX": 1.57623774E12, "title": "Latencies Over Time"}},
        getOptions: function() {
            return {
                series: {
                    lines: {
                        show: true
                    },
                    points: {
                        show: true
                    }
                },
                xaxis: {
                    mode: "time",
                    timeformat: getTimeFormat(this.data.result.granularity),
                    axisLabel: getElapsedTimeLabel(this.data.result.granularity),
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                yaxis: {
                    axisLabel: "Average response latencies in ms",
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                legend: {
                    noColumns: 2,
                    show: true,
                    container: '#legendLatenciesOverTime'
                },
                selection: {
                    mode: 'xy'
                },
                grid: {
                    hoverable: true // IMPORTANT! this is needed for tooltip to
                                    // work
                },
                tooltip: true,
                tooltipOpts: {
                    content: "%s : at %x Average latency was %y ms"
                }
            };
        },
        createGraph: function () {
            var data = this.data;
            var dataset = prepareData(data.result.series, $("#choicesLatenciesOverTime"));
            var options = this.getOptions();
            prepareOptions(options, data);
            $.plot($("#flotLatenciesOverTime"), dataset, options);
            // setup overview
            $.plot($("#overviewLatenciesOverTime"), dataset, prepareOverviewOptions(options));
        }
};

// Latencies Over Time
function refreshLatenciesOverTime(fixTimestamps) {
    var infos = latenciesOverTimeInfos;
    prepareSeries(infos.data);
    if(infos.data.result.series.length == 0) {
        setEmptyGraph("#bodyLatenciesOverTime");
        return;
    }
    if(fixTimestamps) {
        fixTimeStamps(infos.data.result.series, 10800000);
    }
    if(isGraph($("#flotLatenciesOverTime"))) {
        infos.createGraph();
    }else {
        var choiceContainer = $("#choicesLatenciesOverTime");
        createLegend(choiceContainer, infos);
        infos.createGraph();
        setGraphZoomable("#flotLatenciesOverTime", "#overviewLatenciesOverTime");
        $('#footerLatenciesOverTime .legendColorBox > div').each(function(i){
            $(this).clone().prependTo(choiceContainer.find("li").eq(i));
        });
    }
};

var connectTimeOverTimeInfos = {
        data: {"result": {"minY": 432.79999999999984, "minX": 1.57623774E12, "maxY": 432.79999999999984, "series": [{"data": [[1.57623774E12, 432.79999999999984]], "isOverall": false, "label": "HTTP Request", "isController": false}], "supportsControllersDiscrimination": true, "granularity": 60000, "maxX": 1.57623774E12, "title": "Connect Time Over Time"}},
        getOptions: function() {
            return {
                series: {
                    lines: {
                        show: true
                    },
                    points: {
                        show: true
                    }
                },
                xaxis: {
                    mode: "time",
                    timeformat: getTimeFormat(this.data.result.granularity),
                    axisLabel: getConnectTimeLabel(this.data.result.granularity),
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                yaxis: {
                    axisLabel: "Average Connect Time in ms",
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                legend: {
                    noColumns: 2,
                    show: true,
                    container: '#legendConnectTimeOverTime'
                },
                selection: {
                    mode: 'xy'
                },
                grid: {
                    hoverable: true // IMPORTANT! this is needed for tooltip to
                                    // work
                },
                tooltip: true,
                tooltipOpts: {
                    content: "%s : at %x Average connect time was %y ms"
                }
            };
        },
        createGraph: function () {
            var data = this.data;
            var dataset = prepareData(data.result.series, $("#choicesConnectTimeOverTime"));
            var options = this.getOptions();
            prepareOptions(options, data);
            $.plot($("#flotConnectTimeOverTime"), dataset, options);
            // setup overview
            $.plot($("#overviewConnectTimeOverTime"), dataset, prepareOverviewOptions(options));
        }
};

// Connect Time Over Time
function refreshConnectTimeOverTime(fixTimestamps) {
    var infos = connectTimeOverTimeInfos;
    prepareSeries(infos.data);
    if(infos.data.result.series.length == 0) {
        setEmptyGraph("#bodyConnectTimeOverTime");
        return;
    }
    if(fixTimestamps) {
        fixTimeStamps(infos.data.result.series, 10800000);
    }
    if(isGraph($("#flotConnectTimeOverTime"))) {
        infos.createGraph();
    }else {
        var choiceContainer = $("#choicesConnectTimeOverTime");
        createLegend(choiceContainer, infos);
        infos.createGraph();
        setGraphZoomable("#flotConnectTimeOverTime", "#overviewConnectTimeOverTime");
        $('#footerConnectTimeOverTime .legendColorBox > div').each(function(i){
            $(this).clone().prependTo(choiceContainer.find("li").eq(i));
        });
    }
};

var responseTimePercentilesOverTimeInfos = {
        data: {"result": {"minY": 279.0, "minX": 1.57623774E12, "maxY": 4479.0, "series": [{"data": [[1.57623774E12, 4479.0]], "isOverall": false, "label": "Max", "isController": false}, {"data": [[1.57623774E12, 279.0]], "isOverall": false, "label": "Min", "isController": false}, {"data": [[1.57623774E12, 3540.9]], "isOverall": false, "label": "90th percentile", "isController": false}, {"data": [[1.57623774E12, 4470.72]], "isOverall": false, "label": "99th percentile", "isController": false}, {"data": [[1.57623774E12, 4295.75]], "isOverall": false, "label": "95th percentile", "isController": false}], "supportsControllersDiscrimination": false, "granularity": 60000, "maxX": 1.57623774E12, "title": "Response Time Percentiles Over Time (successful requests only)"}},
        getOptions: function() {
            return {
                series: {
                    lines: {
                        show: true,
                        fill: true
                    },
                    points: {
                        show: true
                    }
                },
                xaxis: {
                    mode: "time",
                    timeformat: getTimeFormat(this.data.result.granularity),
                    axisLabel: getElapsedTimeLabel(this.data.result.granularity),
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                yaxis: {
                    axisLabel: "Response Time in ms",
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                legend: {
                    noColumns: 2,
                    show: true,
                    container: '#legendResponseTimePercentilesOverTime'
                },
                selection: {
                    mode: 'xy'
                },
                grid: {
                    hoverable: true // IMPORTANT! this is needed for tooltip to
                                    // work
                },
                tooltip: true,
                tooltipOpts: {
                    content: "%s : at %x Response time was %y ms"
                }
            };
        },
        createGraph: function () {
            var data = this.data;
            var dataset = prepareData(data.result.series, $("#choicesResponseTimePercentilesOverTime"));
            var options = this.getOptions();
            prepareOptions(options, data);
            $.plot($("#flotResponseTimePercentilesOverTime"), dataset, options);
            // setup overview
            $.plot($("#overviewResponseTimePercentilesOverTime"), dataset, prepareOverviewOptions(options));
        }
};

// Response Time Percentiles Over Time
function refreshResponseTimePercentilesOverTime(fixTimestamps) {
    var infos = responseTimePercentilesOverTimeInfos;
    prepareSeries(infos.data);
    if(fixTimestamps) {
        fixTimeStamps(infos.data.result.series, 10800000);
    }
    if(isGraph($("#flotResponseTimePercentilesOverTime"))) {
        infos.createGraph();
    }else {
        var choiceContainer = $("#choicesResponseTimePercentilesOverTime");
        createLegend(choiceContainer, infos);
        infos.createGraph();
        setGraphZoomable("#flotResponseTimePercentilesOverTime", "#overviewResponseTimePercentilesOverTime");
        $('#footerResponseTimePercentilesOverTime .legendColorBox > div').each(function(i){
            $(this).clone().prependTo(choiceContainer.find("li").eq(i));
        });
    }
};


var responseTimeVsRequestInfos = {
    data: {"result": {"minY": 818.0, "minX": 1.0, "maxY": 3458.0, "series": [{"data": [[4.0, 1473.0], [16.0, 1968.0], [1.0, 1753.5], [8.0, 2327.5], [17.0, 2040.0], [9.0, 2218.0], [5.0, 2798.0], [11.0, 2979.0], [24.0, 3458.0], [14.0, 2126.0], [15.0, 2165.0]], "isOverall": false, "label": "Successes", "isController": false}, {"data": [[24.0, 1991.0], [14.0, 818.0]], "isOverall": false, "label": "Failures", "isController": false}], "supportsControllersDiscrimination": false, "granularity": 1000, "maxX": 24.0, "title": "Response Time Vs Request"}},
    getOptions: function() {
        return {
            series: {
                lines: {
                    show: false
                },
                points: {
                    show: true
                }
            },
            xaxis: {
                axisLabel: "Global number of requests per second",
                axisLabelUseCanvas: true,
                axisLabelFontSizePixels: 12,
                axisLabelFontFamily: 'Verdana, Arial',
                axisLabelPadding: 20,
            },
            yaxis: {
                axisLabel: "Median Response Time in ms",
                axisLabelUseCanvas: true,
                axisLabelFontSizePixels: 12,
                axisLabelFontFamily: 'Verdana, Arial',
                axisLabelPadding: 20,
            },
            legend: {
                noColumns: 2,
                show: true,
                container: '#legendResponseTimeVsRequest'
            },
            selection: {
                mode: 'xy'
            },
            grid: {
                hoverable: true // IMPORTANT! this is needed for tooltip to work
            },
            tooltip: true,
            tooltipOpts: {
                content: "%s : Median response time at %x req/s was %y ms"
            },
            colors: ["#9ACD32", "#FF6347"]
        };
    },
    createGraph: function () {
        var data = this.data;
        var dataset = prepareData(data.result.series, $("#choicesResponseTimeVsRequest"));
        var options = this.getOptions();
        prepareOptions(options, data);
        $.plot($("#flotResponseTimeVsRequest"), dataset, options);
        // setup overview
        $.plot($("#overviewResponseTimeVsRequest"), dataset, prepareOverviewOptions(options));

    }
};

// Response Time vs Request
function refreshResponseTimeVsRequest() {
    var infos = responseTimeVsRequestInfos;
    prepareSeries(infos.data);
    if (isGraph($("#flotResponseTimeVsRequest"))){
        infos.createGraph();
    }else{
        var choiceContainer = $("#choicesResponseTimeVsRequest");
        createLegend(choiceContainer, infos);
        infos.createGraph();
        setGraphZoomable("#flotResponseTimeVsRequest", "#overviewResponseTimeVsRequest");
        $('#footerResponseRimeVsRequest .legendColorBox > div').each(function(i){
            $(this).clone().prependTo(choiceContainer.find("li").eq(i));
        });
    }
};


var latenciesVsRequestInfos = {
    data: {"result": {"minY": 818.0, "minX": 1.0, "maxY": 3367.0, "series": [{"data": [[4.0, 1446.0], [16.0, 1944.5], [1.0, 1709.5], [8.0, 2307.5], [17.0, 2036.0], [9.0, 2177.5], [5.0, 2733.0], [11.0, 2938.0], [24.0, 3367.0], [14.0, 2090.0], [15.0, 2114.0]], "isOverall": false, "label": "Successes", "isController": false}, {"data": [[24.0, 1991.0], [14.0, 818.0]], "isOverall": false, "label": "Failures", "isController": false}], "supportsControllersDiscrimination": false, "granularity": 1000, "maxX": 24.0, "title": "Latencies Vs Request"}},
    getOptions: function() {
        return{
            series: {
                lines: {
                    show: false
                },
                points: {
                    show: true
                }
            },
            xaxis: {
                axisLabel: "Global number of requests per second",
                axisLabelUseCanvas: true,
                axisLabelFontSizePixels: 12,
                axisLabelFontFamily: 'Verdana, Arial',
                axisLabelPadding: 20,
            },
            yaxis: {
                axisLabel: "Median Latency in ms",
                axisLabelUseCanvas: true,
                axisLabelFontSizePixels: 12,
                axisLabelFontFamily: 'Verdana, Arial',
                axisLabelPadding: 20,
            },
            legend: { noColumns: 2,show: true, container: '#legendLatencyVsRequest' },
            selection: {
                mode: 'xy'
            },
            grid: {
                hoverable: true // IMPORTANT! this is needed for tooltip to work
            },
            tooltip: true,
            tooltipOpts: {
                content: "%s : Median Latency time at %x req/s was %y ms"
            },
            colors: ["#9ACD32", "#FF6347"]
        };
    },
    createGraph: function () {
        var data = this.data;
        var dataset = prepareData(data.result.series, $("#choicesLatencyVsRequest"));
        var options = this.getOptions();
        prepareOptions(options, data);
        $.plot($("#flotLatenciesVsRequest"), dataset, options);
        // setup overview
        $.plot($("#overviewLatenciesVsRequest"), dataset, prepareOverviewOptions(options));
    }
};

// Latencies vs Request
function refreshLatenciesVsRequest() {
        var infos = latenciesVsRequestInfos;
        prepareSeries(infos.data);
        if(isGraph($("#flotLatenciesVsRequest"))){
            infos.createGraph();
        }else{
            var choiceContainer = $("#choicesLatencyVsRequest");
            createLegend(choiceContainer, infos);
            infos.createGraph();
            setGraphZoomable("#flotLatenciesVsRequest", "#overviewLatenciesVsRequest");
            $('#footerLatenciesVsRequest .legendColorBox > div').each(function(i){
                $(this).clone().prependTo(choiceContainer.find("li").eq(i));
            });
        }
};

var hitsPerSecondInfos = {
        data: {"result": {"minY": 3.0, "minX": 1.57623774E12, "maxY": 3.0, "series": [{"data": [[1.57623774E12, 3.0]], "isOverall": false, "label": "hitsPerSecond", "isController": false}], "supportsControllersDiscrimination": false, "granularity": 60000, "maxX": 1.57623774E12, "title": "Hits Per Second"}},
        getOptions: function() {
            return {
                series: {
                    lines: {
                        show: true
                    },
                    points: {
                        show: true
                    }
                },
                xaxis: {
                    mode: "time",
                    timeformat: getTimeFormat(this.data.result.granularity),
                    axisLabel: getElapsedTimeLabel(this.data.result.granularity),
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                yaxis: {
                    axisLabel: "Number of hits / sec",
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20
                },
                legend: {
                    noColumns: 2,
                    show: true,
                    container: "#legendHitsPerSecond"
                },
                selection: {
                    mode : 'xy'
                },
                grid: {
                    hoverable: true // IMPORTANT! this is needed for tooltip to
                                    // work
                },
                tooltip: true,
                tooltipOpts: {
                    content: "%s at %x was %y.2 hits/sec"
                }
            };
        },
        createGraph: function createGraph() {
            var data = this.data;
            var dataset = prepareData(data.result.series, $("#choicesHitsPerSecond"));
            var options = this.getOptions();
            prepareOptions(options, data);
            $.plot($("#flotHitsPerSecond"), dataset, options);
            // setup overview
            $.plot($("#overviewHitsPerSecond"), dataset, prepareOverviewOptions(options));
        }
};

// Hits per second
function refreshHitsPerSecond(fixTimestamps) {
    var infos = hitsPerSecondInfos;
    prepareSeries(infos.data);
    if(fixTimestamps) {
        fixTimeStamps(infos.data.result.series, 10800000);
    }
    if (isGraph($("#flotHitsPerSecond"))){
        infos.createGraph();
    }else{
        var choiceContainer = $("#choicesHitsPerSecond");
        createLegend(choiceContainer, infos);
        infos.createGraph();
        setGraphZoomable("#flotHitsPerSecond", "#overviewHitsPerSecond");
        $('#footerHitsPerSecond .legendColorBox > div').each(function(i){
            $(this).clone().prependTo(choiceContainer.find("li").eq(i));
        });
    }
}

var codesPerSecondInfos = {
        data: {"result": {"minY": 0.08333333333333333, "minX": 1.57623774E12, "maxY": 2.8, "series": [{"data": [[1.57623774E12, 2.8]], "isOverall": false, "label": "200", "isController": false}, {"data": [[1.57623774E12, 0.11666666666666667]], "isOverall": false, "label": "500", "isController": false}, {"data": [[1.57623774E12, 0.08333333333333333]], "isOverall": false, "label": "404", "isController": false}], "supportsControllersDiscrimination": false, "granularity": 60000, "maxX": 1.57623774E12, "title": "Codes Per Second"}},
        getOptions: function(){
            return {
                series: {
                    lines: {
                        show: true
                    },
                    points: {
                        show: true
                    }
                },
                xaxis: {
                    mode: "time",
                    timeformat: getTimeFormat(this.data.result.granularity),
                    axisLabel: getElapsedTimeLabel(this.data.result.granularity),
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                yaxis: {
                    axisLabel: "Number of responses / sec",
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                legend: {
                    noColumns: 2,
                    show: true,
                    container: "#legendCodesPerSecond"
                },
                selection: {
                    mode: 'xy'
                },
                grid: {
                    hoverable: true // IMPORTANT! this is needed for tooltip to
                                    // work
                },
                tooltip: true,
                tooltipOpts: {
                    content: "Number of Response Codes %s at %x was %y.2 responses / sec"
                }
            };
        },
    createGraph: function() {
        var data = this.data;
        var dataset = prepareData(data.result.series, $("#choicesCodesPerSecond"));
        var options = this.getOptions();
        prepareOptions(options, data);
        $.plot($("#flotCodesPerSecond"), dataset, options);
        // setup overview
        $.plot($("#overviewCodesPerSecond"), dataset, prepareOverviewOptions(options));
    }
};

// Codes per second
function refreshCodesPerSecond(fixTimestamps) {
    var infos = codesPerSecondInfos;
    prepareSeries(infos.data);
    if(fixTimestamps) {
        fixTimeStamps(infos.data.result.series, 10800000);
    }
    if(isGraph($("#flotCodesPerSecond"))){
        infos.createGraph();
    }else{
        var choiceContainer = $("#choicesCodesPerSecond");
        createLegend(choiceContainer, infos);
        infos.createGraph();
        setGraphZoomable("#flotCodesPerSecond", "#overviewCodesPerSecond");
        $('#footerCodesPerSecond .legendColorBox > div').each(function(i){
            $(this).clone().prependTo(choiceContainer.find("li").eq(i));
        });
    }
};

var transactionsPerSecondInfos = {
        data: {"result": {"minY": 0.2, "minX": 1.57623774E12, "maxY": 2.8, "series": [{"data": [[1.57623774E12, 2.8]], "isOverall": false, "label": "HTTP Request-success", "isController": false}, {"data": [[1.57623774E12, 0.2]], "isOverall": false, "label": "HTTP Request-failure", "isController": false}], "supportsControllersDiscrimination": true, "granularity": 60000, "maxX": 1.57623774E12, "title": "Transactions Per Second"}},
        getOptions: function(){
            return {
                series: {
                    lines: {
                        show: true
                    },
                    points: {
                        show: true
                    }
                },
                xaxis: {
                    mode: "time",
                    timeformat: getTimeFormat(this.data.result.granularity),
                    axisLabel: getElapsedTimeLabel(this.data.result.granularity),
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                yaxis: {
                    axisLabel: "Number of transactions / sec",
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20
                },
                legend: {
                    noColumns: 2,
                    show: true,
                    container: "#legendTransactionsPerSecond"
                },
                selection: {
                    mode: 'xy'
                },
                grid: {
                    hoverable: true // IMPORTANT! this is needed for tooltip to
                                    // work
                },
                tooltip: true,
                tooltipOpts: {
                    content: "%s at %x was %y transactions / sec"
                }
            };
        },
    createGraph: function () {
        var data = this.data;
        var dataset = prepareData(data.result.series, $("#choicesTransactionsPerSecond"));
        var options = this.getOptions();
        prepareOptions(options, data);
        $.plot($("#flotTransactionsPerSecond"), dataset, options);
        // setup overview
        $.plot($("#overviewTransactionsPerSecond"), dataset, prepareOverviewOptions(options));
    }
};

// Transactions per second
function refreshTransactionsPerSecond(fixTimestamps) {
    var infos = transactionsPerSecondInfos;
    prepareSeries(infos.data);
    if(infos.data.result.series.length == 0) {
        setEmptyGraph("#bodyTransactionsPerSecond");
        return;
    }
    if(fixTimestamps) {
        fixTimeStamps(infos.data.result.series, 10800000);
    }
    if(isGraph($("#flotTransactionsPerSecond"))){
        infos.createGraph();
    }else{
        var choiceContainer = $("#choicesTransactionsPerSecond");
        createLegend(choiceContainer, infos);
        infos.createGraph();
        setGraphZoomable("#flotTransactionsPerSecond", "#overviewTransactionsPerSecond");
        $('#footerTransactionsPerSecond .legendColorBox > div').each(function(i){
            $(this).clone().prependTo(choiceContainer.find("li").eq(i));
        });
    }
};

var totalTPSInfos = {
        data: {"result": {"minY": 0.2, "minX": 1.57623774E12, "maxY": 2.8, "series": [{"data": [[1.57623774E12, 2.8]], "isOverall": false, "label": "Transaction-success", "isController": false}, {"data": [[1.57623774E12, 0.2]], "isOverall": false, "label": "Transaction-failure", "isController": false}], "supportsControllersDiscrimination": true, "granularity": 60000, "maxX": 1.57623774E12, "title": "Total Transactions Per Second"}},
        getOptions: function(){
            return {
                series: {
                    lines: {
                        show: true
                    },
                    points: {
                        show: true
                    }
                },
                xaxis: {
                    mode: "time",
                    timeformat: getTimeFormat(this.data.result.granularity),
                    axisLabel: getElapsedTimeLabel(this.data.result.granularity),
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                yaxis: {
                    axisLabel: "Number of transactions / sec",
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20
                },
                legend: {
                    noColumns: 2,
                    show: true,
                    container: "#legendTotalTPS"
                },
                selection: {
                    mode: 'xy'
                },
                grid: {
                    hoverable: true // IMPORTANT! this is needed for tooltip to
                                    // work
                },
                tooltip: true,
                tooltipOpts: {
                    content: "%s at %x was %y transactions / sec"
                },
                colors: ["#9ACD32", "#FF6347"]
            };
        },
    createGraph: function () {
        var data = this.data;
        var dataset = prepareData(data.result.series, $("#choicesTotalTPS"));
        var options = this.getOptions();
        prepareOptions(options, data);
        $.plot($("#flotTotalTPS"), dataset, options);
        // setup overview
        $.plot($("#overviewTotalTPS"), dataset, prepareOverviewOptions(options));
    }
};

// Total Transactions per second
function refreshTotalTPS(fixTimestamps) {
    var infos = totalTPSInfos;
    // We want to ignore seriesFilter
    prepareSeries(infos.data, false, true);
    if(fixTimestamps) {
        fixTimeStamps(infos.data.result.series, 10800000);
    }
    if(isGraph($("#flotTotalTPS"))){
        infos.createGraph();
    }else{
        var choiceContainer = $("#choicesTotalTPS");
        createLegend(choiceContainer, infos);
        infos.createGraph();
        setGraphZoomable("#flotTotalTPS", "#overviewTotalTPS");
        $('#footerTotalTPS .legendColorBox > div').each(function(i){
            $(this).clone().prependTo(choiceContainer.find("li").eq(i));
        });
    }
};

// Collapse the graph matching the specified DOM element depending the collapsed
// status
function collapse(elem, collapsed){
    if(collapsed){
        $(elem).parent().find(".fa-chevron-up").removeClass("fa-chevron-up").addClass("fa-chevron-down");
    } else {
        $(elem).parent().find(".fa-chevron-down").removeClass("fa-chevron-down").addClass("fa-chevron-up");
        if (elem.id == "bodyBytesThroughputOverTime") {
            if (isGraph($(elem).find('.flot-chart-content')) == false) {
                refreshBytesThroughputOverTime(true);
            }
            document.location.href="#bytesThroughputOverTime";
        } else if (elem.id == "bodyLatenciesOverTime") {
            if (isGraph($(elem).find('.flot-chart-content')) == false) {
                refreshLatenciesOverTime(true);
            }
            document.location.href="#latenciesOverTime";
        } else if (elem.id == "bodyCustomGraph") {
            if (isGraph($(elem).find('.flot-chart-content')) == false) {
                refreshCustomGraph(true);
            }
            document.location.href="#responseCustomGraph";
        } else if (elem.id == "bodyConnectTimeOverTime") {
            if (isGraph($(elem).find('.flot-chart-content')) == false) {
                refreshConnectTimeOverTime(true);
            }
            document.location.href="#connectTimeOverTime";
        } else if (elem.id == "bodyResponseTimePercentilesOverTime") {
            if (isGraph($(elem).find('.flot-chart-content')) == false) {
                refreshResponseTimePercentilesOverTime(true);
            }
            document.location.href="#responseTimePercentilesOverTime";
        } else if (elem.id == "bodyResponseTimeDistribution") {
            if (isGraph($(elem).find('.flot-chart-content')) == false) {
                refreshResponseTimeDistribution();
            }
            document.location.href="#responseTimeDistribution" ;
        } else if (elem.id == "bodySyntheticResponseTimeDistribution") {
            if (isGraph($(elem).find('.flot-chart-content')) == false) {
                refreshSyntheticResponseTimeDistribution();
            }
            document.location.href="#syntheticResponseTimeDistribution" ;
        } else if (elem.id == "bodyActiveThreadsOverTime") {
            if (isGraph($(elem).find('.flot-chart-content')) == false) {
                refreshActiveThreadsOverTime(true);
            }
            document.location.href="#activeThreadsOverTime";
        } else if (elem.id == "bodyTimeVsThreads") {
            if (isGraph($(elem).find('.flot-chart-content')) == false) {
                refreshTimeVsThreads();
            }
            document.location.href="#timeVsThreads" ;
        } else if (elem.id == "bodyCodesPerSecond") {
            if (isGraph($(elem).find('.flot-chart-content')) == false) {
                refreshCodesPerSecond(true);
            }
            document.location.href="#codesPerSecond";
        } else if (elem.id == "bodyTransactionsPerSecond") {
            if (isGraph($(elem).find('.flot-chart-content')) == false) {
                refreshTransactionsPerSecond(true);
            }
            document.location.href="#transactionsPerSecond";
        } else if (elem.id == "bodyTotalTPS") {
            if (isGraph($(elem).find('.flot-chart-content')) == false) {
                refreshTotalTPS(true);
            }
            document.location.href="#totalTPS";
        } else if (elem.id == "bodyResponseTimeVsRequest") {
            if (isGraph($(elem).find('.flot-chart-content')) == false) {
                refreshResponseTimeVsRequest();
            }
            document.location.href="#responseTimeVsRequest";
        } else if (elem.id == "bodyLatenciesVsRequest") {
            if (isGraph($(elem).find('.flot-chart-content')) == false) {
                refreshLatenciesVsRequest();
            }
            document.location.href="#latencyVsRequest";
        }
    }
}

/*
 * Activates or deactivates all series of the specified graph (represented by id parameter)
 * depending on checked argument.
 */
function toggleAll(id, checked){
    var placeholder = document.getElementById(id);

    var cases = $(placeholder).find(':checkbox');
    cases.prop('checked', checked);
    $(cases).parent().children().children().toggleClass("legend-disabled", !checked);

    var choiceContainer;
    if ( id == "choicesBytesThroughputOverTime"){
        choiceContainer = $("#choicesBytesThroughputOverTime");
        refreshBytesThroughputOverTime(false);
    } else if(id == "choicesResponseTimesOverTime"){
        choiceContainer = $("#choicesResponseTimesOverTime");
        refreshResponseTimeOverTime(false);
    }else if(id == "choicesResponseCustomGraph"){
        choiceContainer = $("#choicesResponseCustomGraph");
        refreshCustomGraph(false);
    } else if ( id == "choicesLatenciesOverTime"){
        choiceContainer = $("#choicesLatenciesOverTime");
        refreshLatenciesOverTime(false);
    } else if ( id == "choicesConnectTimeOverTime"){
        choiceContainer = $("#choicesConnectTimeOverTime");
        refreshConnectTimeOverTime(false);
    } else if ( id == "choicesResponseTimePercentilesOverTime"){
        choiceContainer = $("#choicesResponseTimePercentilesOverTime");
        refreshResponseTimePercentilesOverTime(false);
    } else if ( id == "choicesResponseTimePercentiles"){
        choiceContainer = $("#choicesResponseTimePercentiles");
        refreshResponseTimePercentiles();
    } else if(id == "choicesActiveThreadsOverTime"){
        choiceContainer = $("#choicesActiveThreadsOverTime");
        refreshActiveThreadsOverTime(false);
    } else if ( id == "choicesTimeVsThreads"){
        choiceContainer = $("#choicesTimeVsThreads");
        refreshTimeVsThreads();
    } else if ( id == "choicesSyntheticResponseTimeDistribution"){
        choiceContainer = $("#choicesSyntheticResponseTimeDistribution");
        refreshSyntheticResponseTimeDistribution();
    } else if ( id == "choicesResponseTimeDistribution"){
        choiceContainer = $("#choicesResponseTimeDistribution");
        refreshResponseTimeDistribution();
    } else if ( id == "choicesHitsPerSecond"){
        choiceContainer = $("#choicesHitsPerSecond");
        refreshHitsPerSecond(false);
    } else if(id == "choicesCodesPerSecond"){
        choiceContainer = $("#choicesCodesPerSecond");
        refreshCodesPerSecond(false);
    } else if ( id == "choicesTransactionsPerSecond"){
        choiceContainer = $("#choicesTransactionsPerSecond");
        refreshTransactionsPerSecond(false);
    } else if ( id == "choicesTotalTPS"){
        choiceContainer = $("#choicesTotalTPS");
        refreshTotalTPS(false);
    } else if ( id == "choicesResponseTimeVsRequest"){
        choiceContainer = $("#choicesResponseTimeVsRequest");
        refreshResponseTimeVsRequest();
    } else if ( id == "choicesLatencyVsRequest"){
        choiceContainer = $("#choicesLatencyVsRequest");
        refreshLatenciesVsRequest();
    }
    var color = checked ? "black" : "#818181";
    if(choiceContainer != null) {
        choiceContainer.find("label").each(function(){
            this.style.color = color;
        });
    }
}

