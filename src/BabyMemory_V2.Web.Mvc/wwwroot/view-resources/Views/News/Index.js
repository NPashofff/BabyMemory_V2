$(function () {
    'use strict';
    const l = abp.localization.getSource('BabyMemory_V2');
    const content = $('#news-wraper');
    //TODO: must hide key
    const apiKey = '262304592d2741dbabf80cd6efe6dbe1';
    const apiUrl = 'https://newsapi.org/v2/everything';

    function getNews() {
        return new Promise((resolve, reject) => {
            $.ajax({
                //todo: make sources variable and pages
                url: `${apiUrl}?sources=bbc-news&pageSize=6&page=1&apiKey=${apiKey}`,
                success: (news) => {
                    resolve(news);
                },
                error: (error) => {
                    reject(error);
                }
            });
        });
    }

    getNews()
        .then((news) => {
            const articles = news.articles;
            for (let i = 0; i < articles.length; i++) {
                const article = articles[i];
                const articleCard = document.createElement('div');
                articleCard.className = "col-md-4 mb-4 d-flex";
                articleCard.style = "width: 18rem;";
                articleCard.innerHTML = `
                    <div class="card elevation-3">
                        <img class="card-img-top mt-2" src="${article.urlToImage}" border="true" alt="Card image cap" style="height: 200px; width: 100%; object-fit: contain">
                        <div class="card-body">
                            <h5 class="card-title"><b>${article.title}<b/></h5>
                            <p class="card-text"><i>${article.description ? article.description : ""} <span><a class="text-muted" href="${article.url}">${l("ReadMore")}: ${article.author}</a></span><i/></p>
                        </div>
                    </div>
                    `;
                content.append(articleCard);
            }
        })
        .catch((error) => {
            console.log(error);
        });
});
