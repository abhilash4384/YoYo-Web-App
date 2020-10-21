// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let totalStoppedPlayers = 0;
const timeout = () => new Promise(resolve => setTimeout(resolve, 1000))
const convertInSeconds = (time) => {
    const minutesToSeconds = parseInt(time.split(':')[0]) * 60;
    const seconds = parseInt(time.split(':')[1]);
    return minutesToSeconds + seconds;
}

const convertSecondsToMinutes = (seconds) => {
    let minutes = Math.floor(seconds / 60);
    let remainingSeconds = seconds - minutes * 60;

    minutes = minutes < 10 ? `0${minutes}` : minutes;
    remainingSeconds = remainingSeconds < 10 ? `0${remainingSeconds}` : remainingSeconds;
    return `${minutes}:${remainingSeconds} m`;
}

const updateProgressBarAndTimers = (totalTime, progressPercent) => {
    $("#progressbar").text(`Progress ${Math.floor(progressPercent)}%`);
    $("#progressbar").attr("style", "width:" + progressPercent + '%');
    $("#total-time").text(convertSecondsToMinutes(totalTime));
};

const updateUI = (currentLevelData, level) => {
    const updatedHtml = `<p class="text-center text-secondary m-0 pt-2">Level ${level}</p>` +
        `<p class="text-center text-secondary m-0">Shuffle ${currentLevelData.ShuttleNo}</p>` +
        `<p class="text-center m-0">${currentLevelData.AccumulatedShuttleDistance / 1000} km/h</p>`;
    $("#circle-content").html(updatedHtml);
}

let configData = null;
const onPlayBtnClick = async (configData) => {
    configData = configData;
    console.log(configData)
    console.log()
    const { fintessRatinngMetaData } = configData;


    let startTimeInSecond = 0;
    let level = 1;
    let totalTime = 0;
    let levelTimer = 0;
    $("#circle-btn").addClass("d-none");
    $("#progressbar-container").removeClass("d-none");
    $("#circle-container").removeClass("d-none");
    $(".btn-container").removeClass("d-none");
    updateUI(fintessRatinngMetaData[0], level);
    do {
        const currentLevelData = fintessRatinngMetaData[level - 1];
        startTimeInSecond = convertInSeconds(currentLevelData.StartTime);
        if ((startTimeInSecond + currentLevelData.LevelTime) <= totalTime) {
            level++;
            levelTimer = 0;
            updateProgressBarAndTimers(totalTime, 0);
            updateUI(currentLevelData, level);
            console.log('level change = ', level);
        } else {
            await timeout();
            totalTime++;
            levelTimer++;
            let progressPercent = (100 * levelTimer) / currentLevelData.LevelTime;
            progressPercent = progressPercent > 100 ? 100 : progressPercent;
            updateProgressBarAndTimers(totalTime, progressPercent);

            console.log('totalTime= ', totalTime);
        }
    } while (level < fintessRatinngMetaData.length && totalStoppedPlayers !== configData.pleayersList.length);

    const updatedHtml = `<p class="text-center text-danger m-0 pt-3">Test Complete</p>`;
    $("#circle-content").html(updatedHtml);
}

const warnPlayer = (playerId) => {
    $(`#btn_warn_${playerId}`).attr("disabled", "true");
    //configData = configData.pleayersList.map(player => {
    //    if (player._id === playerId) {
    //        player.isWarned = true;
    //    }
    //});
}

const stopPlayer = (playerId) => {
    $(`.btn_container_${playerId}`).addClass('d-none');
    $(`#drowpdown_container_${playerId}`).removeClass('d-none');
    
    //configData = configData.pleayersList.map(player => {
    //    if (player._id === playerId) {
    //        player.isStopped = true;
    //    }
    //});
    totalStoppedPlayers++;
} 