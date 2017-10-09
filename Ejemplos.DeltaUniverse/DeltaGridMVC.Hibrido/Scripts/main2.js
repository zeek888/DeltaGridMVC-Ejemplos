$(function () {
    //BEGIN MENU SIDEBAR
    $('#sidebar').css('min-height', '100%');
    $('#side-menu').metisMenu();

    $(window).bind("load resize", function () {
        if ($(this).width() < 768) {
            $('div.sidebar-collapse').addClass('collapse');
        } else {
            $('div.sidebar-collapse').removeClass('collapse');
            $('div.sidebar-collapse').css('height', 'auto');
        }
        if($('body').hasClass('sidebar-icons')){
            $('#menu-toggle').hide();
        } else{
            $('#menu-toggle').show();
        }
    });
    //END MENU SIDEBAR

    
    
    //BEGIN TOOTLIP
    $("[data-toggle='tooltip'], [data-hover='tooltip']").tooltip();
    //END TOOLTIP

    //BEGIN POPOVER
    $("[data-toggle='popover'], [data-hover='popover']").popover();
    //END POPOVER

    //BEGIN THEME SETTING
    $('#theme-setting > a.btn-theme-setting').click(function(){
        if($('#theme-setting').css('right') < '0'){
            $('#theme-setting').css('right', '0');
        } else {
            $('#theme-setting').css('right', '-250px');
        }
    });

    //BEGIN FULL SCREEN
    $('.btn-fullscreen').click(function() {

        if (!document.fullscreenElement &&    // alternative standard method
            !document.mozFullScreenElement && !document.webkitFullscreenElement && !document.msFullscreenElement ) {  // current working methods
            if (document.documentElement.requestFullscreen) {
                document.documentElement.requestFullscreen();
            } else if (document.documentElement.msRequestFullscreen) {
                document.documentElement.msRequestFullscreen();
            } else if (document.documentElement.mozRequestFullScreen) {
                document.documentElement.mozRequestFullScreen();
            } else if (document.documentElement.webkitRequestFullscreen) {
                document.documentElement.webkitRequestFullscreen(Element.ALLOW_KEYBOARD_INPUT);
            }
        } else {
            if (document.exitFullscreen) {
                document.exitFullscreen();
            } else if (document.msExitFullscreen) {
                document.msExitFullscreen();
            } else if (document.mozCancelFullScreen) {
                document.mozCancelFullScreen();
            } else if (document.webkitExitFullscreen) {
                document.webkitExitFullscreen();
            }
        }
    });
    //END FULL SCREEN

    // BEGIN FORM CHAT
    $('.btn-chat').click(function () {
        if($('#chat-box').is(':visible')){
            $('#chat-form').toggle('slide', {
                direction: 'right'
            }, 500);
            $('#chat-box').hide();
        } else{
            $('#chat-form').toggle('slide', {
                direction: 'right'
            }, 500);
        }
    });
    $('.chat-box-close').click(function(){
        $('#chat-box').hide();
        $('#chat-form .chat-group a').removeClass('active');
    });
    $('.chat-form-close').click(function(){
        $('#chat-form').toggle('slide', {
            direction: 'right'
        }, 500);
        $('#chat-box').hide();
    });

    $('#chat-form .chat-group a').unbind('*').click(function(){
        $('#chat-box').hide();
        $('#chat-form .chat-group a').removeClass('active');
        $(this).addClass('active');
        var strUserName = $('> small', this).text();
        $('.display-name', '#chat-box').html(strUserName);
        var userStatus = $(this).find('span.user-status').attr('class');
        $('#chat-box > .chat-box-header > span.user-status').removeClass().addClass(userStatus);
        var chatBoxStatus = $('span.user-status', '#chat-box');
        var chatBoxStatusShow = $('#chat-box > .chat-box-header > small');
        if(chatBoxStatus.hasClass('is-online')){
            chatBoxStatusShow.html('Online');
        } else if(chatBoxStatus.hasClass('is-offline')){
            chatBoxStatusShow.html('Offline');
        } else if(chatBoxStatus.hasClass('is-busy')){
            chatBoxStatusShow.html('Busy');
        } else if(chatBoxStatus.hasClass('is-idle')){
            chatBoxStatusShow.html('Idle');
        }


        var offset = $(this).offset();
        var h_main = $('#chat-form').height();
        var h_title = $("#chat-box > .chat-box-header").height();
        var top = ($('#chat-box').is(':visible') ? (offset.top - h_title - 40) : (offset.top + h_title - 20));

        if((top + $('#chat-box').height()) > h_main){
            top = h_main - 	$('#chat-box').height();
        }

        $('#chat-box').css({'top': top});

        if(!$('#chat-box').is(':visible')){
            $('#chat-box').toggle('slide',{
                direction: 'right'
            }, 500);
        }
        // FOCUS INPUT TExT WHEN CLICK
        $('ul.chat-box-body').scrollTop(500);
        $("#chat-box .chat-textarea input").focus();
    });
    // Add content to form
    $('.chat-textarea input').on("keypress", function(e){

        var $obj = $(this);
        var $me = $obj.parent().parent().find('ul.chat-box-body');
        var $my_avt = 'https://s3.amazonaws.com/uifaces/faces/twitter/kolage/128.jpg';
        var $your_avt = 'https://s3.amazonaws.com/uifaces/faces/twitter/alagoon/48.jpg';
        if (e.which == 13) {
            var $content = $obj.val();

            if ($content !== "") {
                var d = new Date();
                var h = d.getHours();
                var m = d.getMinutes();
                if (m < 10) m = "0" + m;
                $obj.val(""); // CLEAR TEXT ON TEXTAREA

                var $element = ""; 
                $element += "<li>";
                $element += "<p>";
                $element += "<img class='avt' src='"+$my_avt+"'>";
                $element += "<span class='user'>John Doe</span>";
                $element += "<span class='time'>" + h + ":" + m + "</span>";
                $element += "</p>";
                $element = $element + "<p>" + $content +  "</p>";
                $element += "</li>";
                
                $me.append($element);
                var height = 0;
                $me.find('li').each(function(i, value){
                    height += parseInt($(this).height());
                });

                height += '';
                //alert(height);
                $me.scrollTop(height);  // add more 400px for #chat-box position      

                // RANDOM RESPOND CHAT

                var $res = "";
                $res += "<li class='odd'>";
                $res += "<p>";
                $res += "<img class='avt' src='"+$your_avt+"'>";
                $res += "<span class='user'>Swlabs</span>";
                $res += "<span class='time'>" + h + ":" + m + "</span>";
                $res += "</p>";
                $res = $res + "<p>" + "Yep! It's so funny :)" + "</p>";
                $res += "</li>";
                setTimeout(function(){
                    $me.append($res);
                    $me.scrollTop(height+100); // add more 500px for #chat-box position             
                }, 1000);
            }
        }
    });
    // END FORM CHAT

    //BEGIN PORTLET
    $(".portlet").each(function(index, element) {
        var me = $(this);
        $(">.portlet-header>.tools>i", me).click(function(e){
            if($(this).hasClass('fa-chevron-up')){
                $(">.portlet-body", me).slideUp('fast');
                $(this).removeClass('fa-chevron-up').addClass('fa-chevron-down');
            }
            else if($(this).hasClass('fa-chevron-down')){
                $(">.portlet-body", me).slideDown('fast');
                $(this).removeClass('fa-chevron-down').addClass('fa-chevron-up');
            }
            else if($(this).hasClass('fa-cog')){
                //Show modal
            }
            else if($(this).hasClass('fa-refresh')){
                //$(">.portlet-body", me).hide();
                $(">.portlet-body", me).addClass('wait');

                setTimeout(function(){
                    //$(">.portlet-body>div", me).show();
                    $(">.portlet-body", me).removeClass('wait');
                }, 1000);
            }
            else if($(this).hasClass('fa-times')){
                me.remove();
            }
        });
    });
    //END PORTLET

    //BEGIN BACK TO TOP
    $(window).scroll(function(){
        if ($(this).scrollTop() < 200) {
            $('#totop') .fadeOut();
        } else {
            $('#totop') .fadeIn();
        }
    });
    $('#totop').on('click', function(){
        $('html, body').animate({scrollTop:0}, 'fast');
        return false;
    });
    //END BACK TO TOP

    //BEGIN CHECKBOX TABLE
    $('.checkall').on('ifChecked ifUnchecked', function(event) {
        if (event.type == 'ifChecked') {
            $(this).closest('table').find('input[type=checkbox]').iCheck('check');
        } else {
            $(this).closest('table').find('input[type=checkbox]').iCheck('uncheck');
        }
    });
    //END CHECKBOX TABLE


});



