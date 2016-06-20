(function ($) {
    function JrjNetwork(placeholder,_id, _options) {

        var obj = this,
            $placeholder = $(placeholder);
            id=_id,
            headerId = function(hId){ return `${id}-panel-header-${hId}`;},
            collapseableBodyId = function(bId){ return `${id}-panel-body-${bId}`; }
            $cc = function (parent, child) { return parent.children("." + child); },
            count = 1,
            cpanelHeaderBar="panel-header-bar",
            
            options = $.extend({
                onClose: function (heading, body, panelbar) { },
                animationTime: 200,
            }, _options),
            $htmlContainer= $placeholder.append(` 
                            <div 
                                class="panel-group" 
                                id="${id}" 
                                role="tablist" 
                                aria-multiselectable="true">
                            </div>`).children();

        function htmlPanel(title, panelid){ 
            return `<div class="panel panel-default" data-panelid="${panelid}">

                        <div class="panel-heading flex-container" role="tab" id="${headerId(panelid)}")">
                            <h4 class="panel-title ">
                                <a  role="button" data-toggle="collapse" data-parent="#${id}")"
                                    href="#${collapseableBodyId(panelid)}"
                                    aria-expanded="false" aria-controls="${collapseableBodyId(panelid)}">
                                        ${title}
                                </a>
                            </h4>
                            <div class="${cpanelHeaderBar} flex-dynamic"> </div>
                            
                            <i class="glyphicon glyphicon-remove"></i>
                        </div>

                        <div id="${collapseableBodyId(panelid)}"
                            class="panel-collapse collapse" role="tabpanel"
                                aria-labelledby="${headerId(panelid)}">
                                <div class="panel-body">                       
                                    
                                </div>
                        </div>

                    </div>
                    `;
        }
        // $htmlContainer.on("div div i",function(){
        //     var $panel = $(this).closest("panel");
        //     alert("hwj");
        //     $panel.replaceWith();
        // })

        // public function
        obj.add = function (title, onAdd = function (_b, _h,_data=null) { }, data=null) {
            var $panel = $htmlContainer.append( htmlPanel(title,count) ).children().last(),

                $headerBar = $panel.find(`.${cpanelHeaderBar}`),
                
                $body = $panel.find(".panel-body").first();
            $panel.find("i").first().on("click", function(){
                //remove the panel and all handlers
                
                $(this).closest(".panel").replaceWith();
            });
            if(data===null)  onAdd($body,$headerBar);
            else            onAdd($body,$headerBar,data);
            
            count++;
        }
    }

    $.jrjNetwork = function (placeholder,id, options) {
        var net = new JrjNetwork(placeholder, id, options);
        return net;
    }
})(jQuery);