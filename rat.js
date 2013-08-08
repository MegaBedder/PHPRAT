$(document).ready(function(){
	poll();
	setInterval("poll()",1000);
	
	$('#output').css({
		width: $(window).width() + 'px',
		height: $(window).height() - 68 + 'px'
	});
	$('#command').css({
		width: $(window).width() + 'px'
	});
	$('#wrapper').css({
		width: $(window).width() + 'px',
		height: $(window).height() - 12 + 'px'
	});
	
	$(window).resize(function(){
		$('#output').css({
			width: $(window).width() + 'px',
			height: $(window).height() - 68 + 'px'
		});
		$('#command').css({
			width: $(window).width() + 'px'
		});
		$('#wrapper').css({
			width: $(window).width() + 'px',
			height: $(window).height() - 12 + 'px'
		});
	});
});


	
function poll() {
	$.get('update.php', function(data) {
		var val = $('#output').html();
		$('#output').html(data);
		if (val !== $('#output').html()) {
			var textarea = document.getElementById("output");
			textarea.scrollTop = textarea.scrollHeight;

			// Work around Chrome's little problem
			window.setTimeout(function() {
				textarea.scrollTop = textarea.scrollHeight;
			}, 1);
		}
	});
}

function fixSelection() {
	var c = document.getElementById('command').selectionStart;
	if (c < 2) {
		document.getElementById('command').selectionStart = 2;
		document.getElementById('command').selectionEnd = 2;
	}
	
}


function preventBackspace(e) {
	var c = document.getElementById('command').selectionStart;
	if (c > 2) return true;
	
	var evt = e || window.event;
	if (evt) {
		var keyCode = evt.charCode || evt.keyCode;
		if (keyCode === 8) {
			if (evt.preventDefault) {
				evt.preventDefault();
			} else {
				evt.returnValue = false;
			}
		}
	}
}

function enter(e) {
	var c = document.getElementById('command').selectionStart;
	if (c < 2) {
		return false;
	}
    if (e.keyCode == 13) {
        send();
        return false;
    }
}

function send() {
	var id = $('#id').val();
	var command = $('#command').val();
	$.get("send.php", { command: command } );
	$('#command').val(">>");
}

function moveCaretToEnd(el) {
    if (typeof el.selectionStart == "number") {
        el.selectionStart = el.selectionEnd = el.value.length;
    } else if (typeof el.createTextRange != "undefined") {
        el.focus();
        var range = el.createTextRange();
        range.collapse(false);
        range.select();
    }
}