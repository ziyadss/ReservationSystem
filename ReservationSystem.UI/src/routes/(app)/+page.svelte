<script>
    import mascot from '$lib/images/mascot.png';
    import { store } from '../../hooks/login.js';
    import { tweened } from 'svelte/motion';
    console.log ($store);
    
    let nextMatchIn = 172800; // 2 days in seconds
    let timer = tweened(nextMatchIn)
    setInterval(() => {
        if($timer > 0) $timer--;
    }, 1000);

    $: days = Math.floor($timer / (3600 * 24));
    $: hours = Math.floor(($timer % (3600 * 24)) / 3600);
    $: minutes = Math.floor(($timer % 3600) / 60);
    $: seconds = Math.floor($timer % 60);
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