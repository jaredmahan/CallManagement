var teapot = {
    add: function (text, url) {
        $('.teapot').on('click', 'a', function (e) {
            e.preventDefault();
            alert("Status 418: I'm a teapot.");
            return;
        });

        // default url
        if (url === undefined) url = '/Home/Teapot';
        
        var value = 'Replace a string';
        var search = /teapot/i;
        return text.replace(search, '<a class="teapot" href="' + url + '">$&</a>');
    },
    remove: function (text) {
        text = teapot.htmlDecode(text);
        return text;
    },
    htmlEncode: function(html) {
        return document.createElement('a').appendChild(
            document.createTextNode(html)).parentNode.innerHTML;
    },
    htmlDecode: function(html) {
        var a = document.createElement('a'); a.innerHTML = html;
        return a.textContent;
    }
};
