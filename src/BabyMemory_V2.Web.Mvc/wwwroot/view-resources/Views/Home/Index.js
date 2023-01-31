$(function () {

    'use strict';
    // news api key: 262304592d2741dbabf80cd6efe6dbe1
    const content = $('#news-wraper');
    const API_KEY = '262304592d2741dbabf80cd6efe6dbe1';
    const API_URL = 'https://newsapi.org/v2/top-headlines';

    function getNews() {
        return new Promise((resolve, reject) => {
            $.ajax({
                url: `${API_URL}?country=us&apiKey=${API_KEY}`,
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
                const articleEl = document.createElement('article');
                articleEl.innerHTML = `
        <h2>${article.title}</h2>
        <p>${article.description}</p>
        <a href="${article.url}" target="_blank">Read more</a>
      `;
                const articleCard = document.createElement('div');
                articleCard.className = "card col-12 col-sm-6 col-md-4 mb-2 d-flex align-items-stretch flex-column";
                articleCard.style = "width: 18rem;";
                articleCard.innerHTML = `
    <img class="card-img-top " src="${article.urlToImage}" border="true" alt="Card image cap">
    <div class="card-body">
        <h5 class="card-title"><b>${article.title}<b/></h5>
        <p class="card-text"><i>${article.description}<i/></p>
        <a href="${article.url}" class="btn btn-primary">Read more</a>
</div>
`;
                console.log(article.title)
                content.append(articleCard);
            }
        })
        .catch((error) => {
            console.log(error);
        });



    /* ChartJS
     * -------
     * Here we will create a few charts using ChartJS
     */

    //-----------------------
    //- MONTHLY SALES CHART -
    //-----------------------

    // Get context with jQuery - using jQuery's .get() method.
   // var salesChartCanvas = $('#salesChart').get(0).getContext('2d');
    // This will get the first returned node in the jQuery collection.

    //var salesChartData = {
    //    labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
    //    datasets: [
    //        {
    //            label: 'Electronics',
    //            fill: '#dee2e6',
    //            borderColor: '#ced4da',
    //            pointBackgroundColor: '#ced4da',
    //            pointBorderColor: '#c1c7d1',
    //            pointHoverBackgroundColor: '#fff',
    //            pointHoverBorderColor: 'rgb(220,220,220)',
    //            spanGaps: true,
    //            data: [65, 59, 80, 81, 56, 55, 40]
    //        },
    //        {
    //            label: 'Digital Goods',
    //            fill: 'rgba(0, 123, 255, 0.9)',
    //            borderColor: 'rgba(0, 123, 255, 1)',
    //            pointBackgroundColor: '#3b8bba',
    //            pointBorderColor: 'rgba(0, 123, 255, 1)',
    //            pointHoverBackgroundColor: '#fff',
    //            pointHoverBorderColor: 'rgba(0, 123, 255, 1)',
    //            spanGaps: true,
    //            data: [28, 48, 40, 19, 86, 27, 90]
    //        }
    //    ]
    //};

    //var salesChartOptions = {
    //    //Boolean - If we should show the scale at all
    //    showScale: true,
    //    //Boolean - Whether grid lines are shown across the chart
    //    scaleShowGridLines: false,
    //    //String - Colour of the grid lines
    //    scaleGridLineColor: 'rgba(0,0,0,.05)',
    //    //Number - Width of the grid lines
    //    scaleGridLineWidth: 1,
    //    //Boolean - Whether to show horizontal lines (except X axis)
    //    scaleShowHorizontalLines: true,
    //    //Boolean - Whether to show vertical lines (except Y axis)
    //    scaleShowVerticalLines: true,
    //    //Boolean - Whether the line is curved between points
    //    bezierCurve: true,
    //    //Number - Tension of the bezier curve between points
    //    bezierCurveTension: 0.3,
    //    //Boolean - Whether to show a dot for each point
    //    pointDot: false,
    //    //Number - Radius of each point dot in pixels
    //    pointDotRadius: 4,
    //    //Number - Pixel width of point dot stroke
    //    pointDotStrokeWidth: 1,
    //    //Number - amount extra to add to the radius to cater for hit detection outside the drawn point
    //    pointHitDetectionRadius: 20,
    //    //Boolean - Whether to show a stroke for datasets
    //    datasetStroke: true,
    //    //Number - Pixel width of dataset stroke
    //    datasetStrokeWidth: 2,
    //    //Boolean - Whether to fill the dataset with a color
    //    datasetFill: true,
    //    //String - A legend template
    //    legendTemplate: '<ul class="<%=name.toLowerCase()%>-legend"><% for (var i=0; i<datasets.length; i++){%><li><span style="background-color:<%=datasets[i].lineColor%>"></span><%=datasets[i].label%></li><%}%></ul>',
    //    //Boolean - whether to maintain the starting aspect ratio or not when responsive, if set to false, will take up entire container
    //    maintainAspectRatio: false,
    //    //Boolean - whether to make the chart responsive to window resizing
    //    responsive: true
    //};

    //Create the line chart
    //var salesChart = new Chart(salesChartCanvas, {
    //    type: 'line',
    //    data: salesChartData,
    //    options: salesChartOptions
    //});

    //---------------------------
    //- END MONTHLY SALES CHART -
    //---------------------------
});
