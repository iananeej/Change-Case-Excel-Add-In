var latestReleaseUrl = "https://api.github.com/repos/aneejian/Change-Case-Excel-Add-In/releases/latest";
var releaseUrl = 'https://github.com/aneejian/Change-Case-Excel-Add-In/releases/download/v3.0/';
var fileName = 'change_case_excel_addin';
var fileTypes = {
    exe: releaseUrl + fileName + '.exe',
    zip: releaseUrl + fileName + '.zip',
    rar: releaseUrl + fileName + '.rar'
}

var totalDownloadCount = 0;
var exeData = {
    url: fileTypes.exe,
    downloads: 0,
    size: '961 KB',
    name: fileName + '.exe'
}
var zipData = {
    url: fileTypes.zip,
    downloads: 0,
    size: '905 KB',
    name: fileName + '.zip'
}
var rarData = {
    url: fileTypes.rar,
    downloads: 0,
    size: '853 KB',
    name: fileName + '.rar'
}

setAssetData();

var settings = {
    "async": true,
    "crossDomain": true,
    "url": "https://api.github.com/repos/aneejian/Change-Case-Excel-Add-In/releases/latest",
    "method": "GET",
    'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8'
};

$.ajax(settings).done(function (response) {
    var assets = response.assets;
    assets.forEach(getAssetData);
    setAssetData();
});


function getAssetData(asset) {
    totalDownloadCount += asset.download_count;
    var assetData = {
        url: asset.browser_download_url,
        downloads: asset.downloads,
        size: Math.round(asset.size / 1024) + ' KB',    
        name: asset.name
    }
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
    $('#totalDownloads').text(totalDownloadCount);    
}

function setAssetData() {
    $('#exe').attr('onclick', "window.location.href='" + exeData.url + "'");
    $('#zip').attr('onclick', "window.location.href='" + zipData.url + "'");
    $('#rar').attr('onclick', "window.location.href='" + rarData.url + "'");
}

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