<script>
    import mascot from '$lib/images/mascot.png';
    import { tweened } from 'svelte/motion';
    import { onMount } from 'svelte';

    const date = new Date();
    let match = {
        homeTeam: '',
        awayTeam: '',
        stadium: '',
        time: date,
        referee: '',
        firstLinesman: '',
        secondLinesman: ''
    }


    let nextMatchIn = 0;

    onMount(async () => {
        await getNextMatch();
    });

    let timer = tweened(nextMatchIn)
    setInterval(() => {
        if($timer > 0) $timer--;
    }, 1000);

    $: days = Math.floor($timer / (3600 * 24));
    $: hours = Math.floor(($timer % (3600 * 24)) / 3600);
    $: minutes = Math.floor(($timer % 3600) / 60);
    $: seconds = Math.floor($timer % 60);

    async function getNextMatch() {
        const response = await fetch('https://localhost:7123/api/matches/next', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
            }
        });
        if (response.ok) {
            const data = await response.json();
            match = data;
            const matchDate = new Date(match.time);
            nextMatchIn = Math.floor(Math.abs(date.getTime() - matchDate.getTime()) / 1000); // 2 days in seconds
            console.log(nextMatchIn);
            timer = tweened(nextMatchIn);
        }
    };
</script>

<svelte:head>
    <title>Qatar 2022&trade;</title>
    <meta name="description" content="Qatar 2022&trade;">
</svelte:head>

<section id="hero">
    <div class="hero-main-container">
        <div class="container">
            <div class="hero-container">
                <div class="hero-content">
                    <h1 class="section-heading">
                        Our football dream starts here!
                    </h1>
                    <p class="paragraph">
                        Come for World Cup matches & explore all over Qatar.
                    </p>
                    <a href="#!" class="btn-primary">
                        <span>Get your tickets</span>
                        <iconify-icon icon="ion:log-out-outline"></iconify-icon>
                    </a>
                    <div class="worldcup-count-down">
                        <div class="count">
                            <h3 class="days">{days}</h3>
                            <span class="count-time">days</span>
                        </div>
                        <div class="count">
                            <h3 class="hours">{hours}</h3>
                            <span class="count-time">hours</span>
                        </div>
                        <div class="count">
                            <h3 class="minutes">{minutes}</h3>
                            <span class="count-time">minutes</span>
                        </div>
                        <div class="count">
                            <h3 class="seconds">{seconds}</h3>
                            <span class="count-time">seconds</span>
                        </div>
                    </div>
                </div>
                <div class="hero-image">
                    <img src="{mascot}" alt="hero-img" class="hero-img" />
                </div>
            </div>
        </div>
    </div>
</section>