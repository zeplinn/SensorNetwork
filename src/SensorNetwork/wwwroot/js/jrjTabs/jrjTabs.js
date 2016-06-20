//jquery tab Plugin

(function ($) {

    function JrjTabs(placeholder, options) {

        var $sc = function (parent, child) { return $(parent).children("." + child); };
        var $cp = function (child, parent) { return $(child).closest("." + parent); };
        // var $find= function(parent,child){ return $find}
        var obj = this,
            count = 1,
            tabcount = 0,
            ctabid = "data-tabid",
            cbar = "jrj-tab-bar",
            ctabs = "jrj-tab-selectors",
            ctab = "jrj-tab-selector",
            cbody = "jrj-tab-body",
            ctext = "jrj-tab-text",
            cclose = "jrj-tab-close",
            cleft = "jrj-tab-left",
            cright = "jrj-tab-right",
            celem = function (i) { return "jrj-tab-elem-" + i },
            cselected = "jrj-selected",
            opt = $.extend({
                body: {
                    height: "200px",
                    content: function (body_) { return null; }
                },
                tabs: {
                    height: "20px"
                },
                onRemove: function (tab_, body_, id_) { },
                width: "100%"

            }, options),
            $tabbar = $sc($(placeholder).append('<div class="' + cbar + '"></div>'), cbar);
        // var $lefttab=$sc($tabbar.append('<i class="'+cleft+'"></i>'),cleft);                        
        var $tabs = $sc($tabbar.append('<ul class="' + ctabs + '"></ul>'), ctabs);
        // var $righttab=$sc($tabbar.append('<i class="'+cright+'"></i>'),cright); 
        var $tabbody = $sc($(placeholder).append('<div class="' + cbody + '"></div>'), cbody);

        function newtab(tabname_) {
            var t = {
                header: '<li class="' + ctab + " " + celem(count) + '" ' + ctabid + '="' + count + '"><div ><a class="' + ctext + '">' + tabname_ + '</a></div><div ><i class="' + cclose + '"></i></div></li>',
                body: '<div class="' + celem(count) + '"></div>'
            };
            count += 1;
            return t;
        }
        function select(tabid) {
            // remove selected from old
            $sc($tabs, cselected).removeClass(cselected);
            $sc($tabbody, cselected).removeClass(cselected);
            //add selection to new
            $sc($tabs, celem(tabid)).addClass(cselected);
            $sc($tabbody, celem(tabid)).addClass(cselected);
        }


        function removeTab(tab_) {
            var tabid_ = tab_.attr(ctabid);

            tab_.off();
            tab_.find("." + cclose).off();
            var t = tab_.detach(),
                b = $sc($tabbody, celem(tabid_)).detach();
            opt.onRemove(t, b, tabid_);
        }
        // $righttab.on("click",function(){
        //     var aa =$tabs.children("li:visible:first");
        //     alert(aa.attr("class"));
        //     aa.toggle();

        //     alert($tabs.children(":first").attr("class"));
        // });
        // $lefttab.on("click",function(){
        //     var aa =$tabs.children("li:hidden:last");
        //     alert(aa.attr("class"));
        //     aa.toggle();
        // });

        obj.addTab = function (tabname_,data, onAddTab = function (_data,t, b) { }) {

            var t = newtab(tabname_),
                $body__ = $sc($tabbody.append(t.body), celem(count - 1)),
                $tab__ = $sc($tabs.append(t.header), celem(count - 1)),
                lopt = $.extend({ select: false },
                    onAddTab(_data, $tab__, $body__));

            //  alert($sc(tab__,ctab).attr("class"));
            $tab__.on("click", function () {
                var tabid_ = $(this).attr(ctabid);
                select(tabid_);
            });
            $tab__.find("." + cclose).on("click", function () {
                var tab_ = $cp(this, ctab);
                removeTab(tab_);
            });

            tabcount += 1;
            if (lopt.select) {
                select(count - 1);
                alert();
            }
        }
    };

    $.jrjTabs = function (placeholder, options) {
        var tab = new JrjTabs(placeholder, options);
        return tab;
    }
    $.fn.jrjTabs = function (options) {
        return this.each(function () {
            $.jrjTabs(this, options);
        });
    };

})(jQuery);