//const cryptoPricesUrl = 'https://api.coingecko.com/api/v3/simple/price?ids=bitcoin,ethereum,litecoin,binancecoin&vs_currencies=usd';

//fetch(cryptoPricesUrl)
//    .then(response => response.json())
//    .then(data => {
//        const bitcoinPrice = data.bitcoin.usd;
//        const ethereumPrice = data.ethereum.usd;
//        const litecoinPrice = data.litecoin.usd;
//        const bnbPrice = data.binancecoin.usd;

//        // update prices on the landing page
//        document.getElementById('bitcoin-price').innerText = `$${bitcoinPrice}`;
//        document.getElementById('ethereum-price').innerText = `$${ethereumPrice}`;
//        document.getElementById('litecoin-price').innerText = `$${litecoinPrice}`;
//        document.getElementById('bnb-price').innerText = `$${bnbPrice}`;
//    })
//    .catch(error => console.error('Error fetching crypto prices:', error));


//const cryptoUrl = `https://api.coingecko.com/api/v3/coins/bitcoin?localization=false&tickers=false&market_data=true&community_data=false&developer_data=false&sparkline=true`;

//fetch(cryptoUrl)
//    .then(response => response.json())
//    .then(data => {
//        const bitcoinPrice = data.market_data.current_price.usd;
//        const bitcoinChange = data.market_data.price_change_percentage_24h;
//        const bitcoinLow = data.market_data.low_24h.usd;
//        const bitcoinHigh = data.market_data.high_24h.usd;
//        const bitcoinOpen = data.market_data.current_price.usd - data.market_data.price_change_24h;
//        const bitcoinVolume = data.market_data.total_volume.usd;
//        const bitcoinChart = data.sparkline_in_7d.price;

//        document.getElementById('bitcoin-price').innerText = `$${bitcoinPrice}`;
//        document.getElementById('bitcoin-change').innerText = ` ${bitcoinChange}%`;
//        document.getElementById('bitcoin-low').innerText = `$${bitcoinLow}`;
//        document.getElementById('bitcoin-high').innerText = `$${bitcoinHigh}`;
//        document.getElementById('bitcoin-open').innerText = ` $${bitcoinOpen}`;
//        document.getElementById('bitcoin-volume').innerText = ` $${bitcoinVolume}`;
//        // render chart using a library of your choice, like Chart.js
//        //const chartEl = document.getElementById('bitcoin-chart');
//        //renderChart(chartEl, bitcoinChart);
//        const chartEl = document.getElementById('bitcoin-chart');
//        const chartData = {
//            labels: [], // Sparkline charts have no labels
//            datasets: [
//                {
//                    label: 'Price',
//                    data: bitcoinChart,
//                    fill: false,
//                    borderColor: 'rgb(75, 192, 192)',
//                    tension: 0.1
//                }
//            ]
//        };
//        const chartOptions = {
//            scales: {
//                y: {
//                    beginAtZero: false
//                }
//            }
//        };
//        const chart = new Chart(chartEl, {
//            type: 'line',
//            data: chartData,
//            options: chartOptions
//        });
//    })

//    .catch(error => console.error('Error fetching Bitcoin price:', error));

////function renderChart(element, data) {
////    // render chart using a library of your choice, like Chart.js
////}

    const apiKey = 'YOUR_API_KEY';
    const cryptoUrl = `https://api.coingecko.com/api/v3/coins/bitcoin?localization=false&tickers=false&market_data=true&community_data=false&developer_data=false&sparkline=true`;

    fetch(cryptoUrl)
    .then(response => response.json())
    .then(data => {
    const bitcoinPrice = data.market_data.current_price.usd;
    const bitcoinChange = data.market_data.price_change_percentage_24h;
    const bitcoinLow = data.market_data.low_24h.usd;
    const bitcoinHigh = data.market_data.high_24h.usd;
    const bitcoinOpen = data.market_data.current_price.usd - data.market_data.price_change_24h;
    const bitcoinVolume = data.market_data.total_volume.usd;
    const bitcoinChart = data.sparkline_in_7d && data.sparkline_in_7d.price;

    document.getElementById('bitcoin-price').innerText = ` $${bitcoinPrice}`;
    document.getElementById('bitcoin-change').innerText = `${bitcoinChange}%`;
    document.getElementById('bitcoin-low').innerText = ` $${bitcoinLow}`;
    document.getElementById('bitcoin-high').innerText = ` $${bitcoinHigh}`;
    document.getElementById('bitcoin-open').innerText = ` $${bitcoinOpen}`;
    document.getElementById('bitcoin-volume').innerText = `$${bitcoinVolume}`;
        
    // Render chart using Chart.js
        const chartEl = document.getElementById('bitcoin-chart');
        const labels = Utils.months({ count: 7 });
        const chartData = {
            labels: [], // Sparkline charts have no labels
    datasets: [
    {
            label: 'price',
            data: bitcoinChart.map((price) => ({ x: labels, y: price })),
    fill: false,
            borderColor: 'rgb(75, 192, 192)',
            backgroundColor: 'rgba(0, 0, 0, 0.1)',
    tension: 0.1
          }
    ]
      };
    const chartOptions = {
        scales: {
        y: {
        beginAtZero: false
          }
        }
      };
    const chart = new Chart(chartEl, {
        type: 'line',
    data: chartData,
    options: chartOptions
      });
    })
    .catch(error => console.error('Error fetching Bitcoin price:', error));



const cryptoUrlEth = `https://api.coingecko.com/api/v3/coins/ethereum?localization=false&tickers=false&market_data=true&community_data=false&developer_data=false&sparkline=true`;

fetch(cryptoUrlEth)
    .then(response => response.json())
    .then(data => {
        const ethereumPrice = data.market_data.current_price.usd;
        const ethereumChange = data.market_data.price_change_percentage_24h;
        const ethereumLow = data.market_data.low_24h.usd;
        const ethereumHigh = data.market_data.high_24h.usd;
        const ethereumOpen = data.market_data.current_price.usd - data.market_data.price_change_24h;
        const ethereumVolume = data.market_data.total_volume.usd;
        

        document.getElementById('ethereum-price').innerText = ` $${ethereumPrice}`;
        document.getElementById('ethereum-change').innerText = `${ethereumChange}%`;
        document.getElementById('ethereum-low').innerText = ` $${ethereumLow}`;
        document.getElementById('ethereum-high').innerText = ` $${ethereumHigh}`;
        document.getElementById('ethereum-open').innerText = ` $${ethereumOpen}`;
        document.getElementById('ethereum-volume').innerText = `$${ethereumVolume}`;

           })
    .catch(error => console.error('Error fetching ethereum price:', error));

const cryptoUrlLTC = `https://api.coingecko.com/api/v3/coins/litecoin?localization=false&tickers=false&market_data=true&community_data=false&developer_data=false&sparkline=true`;

fetch(cryptoUrlLTC)
    .then(response => response.json())
    .then(data => {
        const litecoinPrice = data.market_data.current_price.usd;
        const litecoinChange = data.market_data.price_change_percentage_24h;
        const litecoinLow = data.market_data.low_24h.usd;
        const litecoinHigh = data.market_data.high_24h.usd;
        const litecoinOpen = data.market_data.current_price.usd - data.market_data.price_change_24h;
        const litecoinVolume = data.market_data.total_volume.usd;


        document.getElementById('litecoin-price').innerText = ` $${litecoinPrice}`;
        document.getElementById('litecoin-change').innerText = `${litecoinChange}%`;
        document.getElementById('litecoin-low').innerText = ` $${litecoinLow}`;
        document.getElementById('litecoin-high').innerText = ` $${litecoinHigh}`;
        document.getElementById('litecoin-open').innerText = ` $${litecoinOpen}`;
        document.getElementById('litecoin-volume').innerText = `$${litecoinVolume}`;

    })
    .catch(error => console.error('Error fetching litecoin price:', error));


const cryptoUrlBNB = `https://api.coingecko.com/api/v3/coins/binancecoin?localization=false&tickers=false&market_data=true&community_data=false&developer_data=false&sparkline=true`;

fetch(cryptoUrlBNB)
    .then(response => response.json())
    .then(data => {
        const binancecoinPrice = data.market_data.current_price.usd;
        const binancecoinChange = data.market_data.price_change_percentage_24h;
        const binancecoinLow = data.market_data.low_24h.usd;
        const binancecoinHigh = data.market_data.high_24h.usd;
        const binancecoinOpen = data.market_data.current_price.usd - data.market_data.price_change_24h;
        const binancecoinVolume = data.market_data.total_volume.usd;


        document.getElementById('binancecoin-price').innerText = ` $${binancecoinPrice}`;
        document.getElementById('binancecoin-change').innerText = `${binancecoinChange}%`;
        document.getElementById('binancecoin-low').innerText = ` $${binancecoinLow}`;
        document.getElementById('binancecoin-high').innerText = ` $${binancecoinHigh}`;
        document.getElementById('binancecoin-open').innerText = ` $${binancecoinOpen}`;
        document.getElementById('binancecoin-volume').innerText = `$${binancecoinVolume}`;

    })
    .catch(error => console.error('Error fetching binance coin price:', error));