// Disqus.js file 

window.loadDisqus = () => {
    var d = document, s = d.createElement('script');
    s.src = 'https://hvac-topgun-blog.disqus.com/embed.js';
    s.setAttribute('data-timestamp', +new Date());
    (d.head || d.body).appendChild(s);
};

window.resetDisqus = (pageUrl, pageIdentifier) => {
    if (typeof DISQUS !== 'undefined') {
        DISQUS.reset({
            reload: true,
            config: function () {
                this.page.identifier = pageIdentifier;
                this.page.url = pageUrl;
            },
        });
    } else {
        console.error('DISQUS is not loaded');
    }
};