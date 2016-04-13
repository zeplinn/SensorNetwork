function staticSchart(identifier) {
    var p = { sensorId: identifier };
    //$.post("api/graph", { "post":"ramadingdong" }, function (data) {
    //    alert(data);
    //});
    $.ajax({
        url: 'api/graph',
        type: 'POST',
        data: JSON.stringify(p),
        contentType: "application/json",
        datatype: "json",
        success: function (result) {

            var options = {
                lines: {
                    show: true
                },
                points: {
                    show: false
                },
                xaxis: {
                    mode: "time",
                    tickSize: [30, "minute"],
                    tickFormatter: function (t, axis) {

                        var date = new Date(t);
                        if (date.getHours() % 3 == 0 && date.getMinutes() == 0) {

                            var hours = date.getHours() < 10 ? "0" + date.getHours() : date.getHours();
                            var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();


                            return hours + ":" + minutes;
                        } else {
                            return "";
                        }
                    }
                },
                yaxis: {
                    min: -20,
                    max: 50,
                    tickFormatter: function (v, axis) {
                        return v;

                    }

                }
            };
            var re = [[[1, 2], [2, 8], [3, -1]]];

            var rre = result;
            $.plot($("#placeholder"), [rre], options);
            //var val = result.values
            //$.flot($('#plotter'),[val])
            //var arr = $.map(result, function (el) { return el });

        }
    });
}


function liveChart(identifier) {
    var cpu = [], cpuCore = [], disk = [];
    var dataset;
    var totalPoints = 100;
    var updateInterval = 1000;
    var now = new Date().getTime();

    function initData() {
        for (var i = 0; i < totalPoints; i++) {
            var temp = [now += updateInterval, 0];

            cpu.push(temp);
            cpuCore.push(temp);
            disk.push(temp);
        }
    }



    var temp;

    function update(_data) {
        //remove first item of array
        cpu.shift();
        cpuCore.shift();
        disk.shift();

        now += updateInterval

        //add the data retrieve from backend to array
        temp = [now, _data.cpu];
        cpu.push(temp);

        temp = [now, _data.core];
        cpuCore.push(temp);

        temp = [now, _data.disk];
        disk.push(temp);

        //update legend label so users can see the latest value in the legend
        dataset = [
            { label: "CPU:" + _data.cpu + "%", data: cpu, lines: { fill: true, lineWidth: 1.2 }, color: "#00FF00" },
            { label: "Disk:" + _data.disk + "KB", data: disk, color: "#0044FF", bars: { show: true }, yaxis: 2 },
            { label: "CPU Core:" + _data.core + "%", data: cpuCore, lines: { lineWidth: 1.2 }, color: "#FF0000" }
        ];

        //redraw the chart
        $.plot($("#flot-placeholder1"), dataset, options);

        //prepare for next update
        setTimeout(GetData, updateInterval);

        function GetData() {
            //set no cache
            $.ajaxSetup({ cache: false });

            $.ajax({
                url: "http://static.jqueryflottutorial.com/AjaxUpdateChart.aspx",
                dataType: 'json',
                success: update,  //if success, call update()
                error: function () {
                    //if fail, prepare next update
                    setTimeout(GetData, updateInterval);
                }
            });
        }
    }
}