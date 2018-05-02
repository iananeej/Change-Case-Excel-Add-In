var apiRoot = "https://api.github.com/";
var latestReleaseUrl = "https://api.github.com/repos/aneejian/Change-Case-Excel-Add-In/releases/latest";
var releaseUrl = 'https://github.com/aneejian/Change-Case-Excel-Add-In/releases/download/v3.0/';
var fileName = 'change_case_excel_addin';
var fileTypes = {
    exe: releaseUrl + fileName + '.exe',
    zip: releaseUrl + fileName + '.zip',
    rar: releaseUrl + fileName + '.rar'
};

var totalDownloadCount = 0;
var exeData = {
    url: fileTypes.exe,
    downloads: 50,
    size: '961 KB',
    name: fileName + '.exe'
};

var zipData = {
    url: fileTypes.zip,
    downloads: 50,
    size: '905 KB',
    name: fileName + '.zip'
};
var rarData = {
    url: fileTypes.rar,
    downloads: 50,
    size: '853 KB',
    name: fileName + '.rar'
};

// setAssetData();

$(window).ready(function () {
    getStats();    
});



// var settings = {
//     "async": true,
//     "crossDomain": true,
//     "url": "https://api.github.com/repos/aneejian/Change-Case-Excel-Add-In/releases/latest",
//     "method": "GET",
// };

// $.ajax(settings).done(function (response) {
//     var assets = response.assets;
//     assets.forEach(getAssetData);
//     setAssetData();
// });




// $('#exe').click(function (e) {
//     e.preventDefault();
//     window.location.href = exeData.url;
// });

// $('#zip').click(function (e) {
//     e.preventDefault();
//     window.location.href = zipData.url;
// });

// $('#rar').click(function (e) {
//     e.preventDefault();
//     window.location.href = rarData.url;
// });


// Callback function for getting release stats
function getStats() {
    var user = 'aneejian';
    var repository = 'Change-Case-Excel-Add-In';
    var url = apiRoot + "repos/" + user + "/" + repository + "/releases/latest";
    $.getJSON(url, setStats).fail(setDownloadLinksAndInfo);
}

function setStats(data){
    var releaseAssets = data.assets;
    $.each(releaseAssets, function (index, item) {
        getAssetData(item);
    });
    setDownloadLinksAndInfo();
}

function getAssetData(asset) {
    totalDownloadCount += asset.download_count;
    var assetData = {
        url: asset.browser_download_url,
        downloads: asset.download_count,
        size: Math.round(asset.size / 1024) + ' KB',
        name: asset.name
    };
    var extension = assetData.name.split('.').pop();
    switch (extension) {
        case 'exe':
            exeData = assetData;
            break;
        case 'zip':
            zipData = assetData;
            break;
        case 'rar':
            rarData = assetData;
            break;
        default:
            break;
    }
}

function setDownloadLinksAndInfo() {
    $('#totalDownloads').text(totalDownloadCount);

    $('#exeName').text(exeData.name);
    $('#exeDownloads').text(exeData.downloads);
    $('#exe').attr('onclick', "window.location.href='" + exeData.url + "'");

    $('#zipName').text(zipData.name);
    $('#zipDownloads').text(zipData.downloads);
    $('#zip').attr('onclick', "window.location.href='" + zipData.url + "'");

    $('#rarName').text(rarData.name);
    $('#rarDownloads').text(rarData.downloads);
    $('#rar').attr('onclick', "window.location.href='" + rarData.url + "'");
}
