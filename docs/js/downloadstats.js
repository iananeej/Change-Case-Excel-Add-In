var totalDownloadCount = 0;
var settings = {
    "async": true,
    "crossDomain": true,
    "url": "https://api.github.com/repos/aneejian/Change-Case-Excel-Add-In/releases/latest",
    "method": "GET"
};

$.ajax(settings).done(function (response) {
    var assets = response.assets;
    assets.forEach(getAssetData);
});

function getAssetData(asset) {
    totalDownloadCount += asset.download_count;
    if (asset.name.endsWith('.exe')) {
        console.log(asset.name);
        console.log(asset.download_count);
        console.log((asset.size / 1048576.0));
    }

    
}