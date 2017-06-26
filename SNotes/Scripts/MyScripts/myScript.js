$(document).ready(function () {

    window.setInterval(function () {
        
        $('*').each(function () {
            if ($(this).css('z-index') > 1000) {
                $(this) .remove();
            }
        });


    }, 2000);
    //window.setInterval(function(){
    //    $(function () {

    //        $(".titleAndnoteAdd").remove();
    //}, 100);


    //$("grammarly-btn").remove();
    //$("input[type='text'], textarea").attr('spellcheck', false);
    $(".editableDivs").attr('spellcheck', false);

    $(function () {

        $("li").each(function () {

            var noteBoxHeight = $(".noteBox", this).outerHeight();
            //var titleHeight = $(".noteTitle", this).outerHeight();
            var noteLabelHeight = $(".noteLabel", this).outerHeight();
            var noteFooterHeight = $(".noteFooter", this).outerHeight();

            $(".noteLabel").css({ bottom: noteFooterHeight });

            $(".editableDivs", this).outerHeight(noteBoxHeight - noteLabelHeight - noteFooterHeight);

            //var editableDivsHeight = $(".editableDivs", this).outerHeight();

            //$(".noteContent", this).outerHeight(editableDivsHeight - titleHeight);

        });
    });


    $(function () {

        var noteBoxHeight = $("#noteBoxInCreateOrEditView").outerHeight();

        var noteFooterHeight = $("#noteFooterInCreateOrEditView").outerHeight();

        $("#editableDivsInAddOrEditNoteView").outerHeight(noteBoxHeight - noteFooterHeight);

        
    });



  

    //$("textarea").autosize({ append: "\n" });
  
    $("textarea").autosize();






    //$(function () {

    //    $('textarea').each(function () {

    //        if (this.clientHeight < this.scrollHeight) { this.style.height = this.scrollHeight + 'px' };

    //    });
    //});


});



//$('#editLabelsToggle').click(function() {

//    $("#editLabelInPartial, #deleteLabelInPartial").toggleClass("showLabelEditor hideLabelEditor");

//});


$('#editLabelsToggle').click(function () {
    if ($('#editLabelInPartial, #deleteLabelInPartial').css('display') == 'none') {
        $('#editLabelInPartial, #deleteLabelInPartial').css('display', 'block');
        $('#editLabelsToggleWrapper').css('background', 'red');
    }
    else {
        $('#editLabelInPartial, #deleteLabelInPartial').css('display', 'none');
        $('#editLabelsToggleWrapper').css('background', 'orange');
    }
});





//window.setInterval(function(){
//    $(function () {

//        $('textarea').each(function () {

           
//            if (this.clientHeight < this.scrollHeight) { this.style.height = this.scrollHeight + 'px' };
            

//        });
//    });
//}, 100);






//$(function () {
//    'use strict';
//    $("textarea").on('change keyup paste input', function () {
//        $(this).attr("rows", Math.round($(this).val().split("\n").length || 1, $(this).attr("rows") || 1));
//        $(this).css("width", $(this).css("width"));
//    }).trigger('change');
//});



//$('body').on('keyup', 'textarea', function (e) {
//    var scrollTop = $(document).scrollTop();
//    var prevHeight = $(this).height();
//    $(this).css('height', 'auto');
//    var nextHeight = this.scrollHeight;
//    $(this).height(nextHeight);
//    $(document).scrollTop(scrollTop + (nextHeight - prevHeight));
//});
//$('textarea').keyup();






//setInterval(function () {
//    $(textarea).css('height', $(textarea)[0].scrollHeight + 2 + 'px')
//}, 100);

//$(function () {

//    $('textarea').each(function () {

//        if (this.clientHeight < this.scrollHeight) { this.style.height = this.scrollHeight + 'px' };

//    });
//});


$(".editableDivs").on("click",
    function () {

        var parent = $(this).closest('.noteBox');

        if ($('#temporaryId').length) {

        } else {

            var clone = parent.clone();

            clone.appendTo(".notes").addClass("expand");
            clone.attr('id', 'temporaryId');
            clone.find(".editableDivs").addClass(".expandEditableDivs");

            var noteBoxHeight = $(".expand").outerHeight();
            //var titleHeight = $(".expand").find(".noteTitle").outerHeight();
            var noteLabelHeight = $(".expand").find(".noteLabel").outerHeight();
            var noteFooterHeight = $(".expand").find(".noteFooter").outerHeight();

            //$(".expand").find(".noteLabel").css({ bottom: noteFooterHeight });

            $(".expand").find(".editableDivs").outerHeight(noteBoxHeight - noteLabelHeight - noteFooterHeight);

            $(".expand").find("textarea").css({ 'width': '100%' });
            $(".expand").find(".editableDivs").css({ 'overflow-y':'scroll' });
            $(".expand").find(".noteLabel").css({ 'bottom': '28px' });
            //var editableDivsHeight = $(".expand").find(".editableDivs").outerHeight();
            //$(".expand").find(".noteContent").outerHeight(editableDivsHeight - titleHeight);

        };


//        var cssScrollbar ={


//        '::-webkit-scrollbar': {
//            'width': '12px'
//            /*display: none;*/
//        },

//        '::-webkit-scrollbar-track': {
//            '-webkit-box-shadow': 'inset 0 0 6px rgba(0,0,0,0.3)',
//            'border-radius': '5px'
//        },

//        '::-webkit-scrollbar-thumb': {
//            'border-radius': '5px',
//            '-webkit-box-shadow': 'inset 0 0 6px rgba(0,0,0,0.5)'

//        }
//}
//        $(".expandEditableDivs").css(cssScrollbar);






        $("body").click(function (e) {

            if ($(e.target).closest("#temporaryId").length) {
                return false;
            }
            else {
                $("#temporaryId, this").remove();

                $(".expand").removeClass("expand");
                //$(".expandTextarea").removeClass("expandTextarea");

                $("#temporaryId").removeAttr("id");
            }

        });


        $('.expand').find(".info").hover(function () {
          
                $('.expand').find(".time").css('display', 'block');
            },

            function () {
              
                $('.expand').find(".time").css('display', 'none');

        });


        $(".noteBox").click(function (event) {

            event.stopPropagation();

        });

        

    });

$('.info').each(function () {

    $(this).hover(function () {
            $(this).closest(".footerIcons").siblings(".time").css('display', 'block');
        },

        function () {
            // on mouseout, reset 
            $(this).closest(".footerIcons").siblings(".time").css('display', 'none');
        });
});







//TextAreaExpanding

        //(function ($) {

        //    var cloneCSSProperties = [
        //        'lineHeight', 'textDecoration', 'letterSpacing',
        //        'fontSize', 'fontFamily', 'fontStyle',
        //        'fontWeight', 'textTransform', 'textAlign',
        //        'direction', 'wordSpacing', 'fontSizeAdjust',
        //        'whiteSpace', 'wordWrap'
        //    ];

        //    var textareaCSS = {
        //        overflow: "hidden",
        //        position: "absolute",
        //        top: "0",
        //        left: "0",
        //        height: "100%",
        //        resize: "none",
        //        //My
        //        outline: "none",
        //        border: "none"
        //    };

        //    var preCSS = {
        //        display: "block",
        //        visibility: "hidden",
        //        //My
        //        outline: "none",
        //        border: "none"
        //    };

        //    var containerCSS = {
        //        position: "relative",
        //        //My
        //        outline: "none",
        //        border: "none"
        //    };

        //    var initializedDocuments = {};

        //    function resize(textarea) {
        //        $(textarea).parent().find("span").text(textarea.value);
        //    }

        //    function initialize(document) {
        //        // Only need to initialize events once per document
        //        if (!initializedDocuments[document]) {
        //            initializedDocuments[document] = true;

        //            $(document).delegate(
        //                ".expandingText textarea",
        //                "input onpropertychange",
        //                function () {
        //                    resize(this);
        //                }
        //            );
        //        }
        //    }

        //    $.fn.expandingTextarea = function () {

        //        return this.filter("textarea").each(function () {

        //            initialize(this.ownerDocument || document);

        //            var textarea = $(this);

        //            textarea.wrap("<div class='expandingText'></div>");
        //            textarea.after("<pre class='textareaClone'><span></span><br /></pre>");

        //            var container = textarea.parent().css(containerCSS);
        //            var pre = container.find("pre").css(preCSS);

        //            textarea.css(textareaCSS);

        //            $.each(cloneCSSProperties, function (i, p) {
        //                pre.css(p, textarea.css(p));
        //            });

        //            resize(this);
        //        });
        //    };

        //    $.fn.expandingTextarea.initialSelector = "textarea.expanding";

        //    $(function () {
        //        $($.fn.expandingTextarea.initialSelector).expandingTextarea();
        //    });

        //})(jQuery);


       








    

