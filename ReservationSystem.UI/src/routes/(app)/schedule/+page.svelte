<script lang="ts">
	import '../../styles.css';
	import arrow from '$lib/images/arrow.png';
	import type { PageData } from './$types';
	import { time_ranges_to_array } from 'svelte/internal';
	import { navigate } from 'svelte-routing';
	export let data: PageData;
	import { browser } from '$app/environment';

	let matches = data.matches;
	function navigateBook(id: number) {
		let _token;
		if (browser) {
			_token = window.localStorage.getItem('token');
		}
		if (_token) {
			window.location.replace('/reservation/' + id);
		} else {
			alert('You need to log in to register a match');
		}
	}
</script>

<svelte:head>
	<title>Match Schedule</title>
	<meta name="description" content="Qatar 2022&trade;" />
	<meta name="viewport" content="width=device-width, initial-scale=1.0" />
</svelte:head>

<div class="schedule-page">
	<div class="container-custom">
		<div class="match-tabs">
			<li class="tab-link">
				<a href="#match-date">Match By Date</a>
			</li>
			<li class="tab-link">
				<a href="#match-group">Match By Group</a>
			</li>
		</div>
		<!-- <h1 class="section-heading">Match By Date</h1> -->
		<div class="matchs" id="match-date">
			{#each matches as match}
				<!-- svelte-ignore a11y-click-events-have-key-events -->
				<div class="match" on:click={() => navigateBook(match.MatchNumber)}>
					<div class="match-info">
						<h4 class="group">{match.Group}</h4>
						<h4>Match Number<span class="badge">{match.MatchNumber}</span></h4>
					</div>
					<div class="flags">
						<div class="home-flag">
							<img src={match.flag[0]} alt={match.HomeTeam} class="flag" />
							<h3 class="home-team">{match.HomeTeam}</h3>
						</div>
						<span class="vs"> VS </span>
						<div class="away-flag">
							<img src={match.flag[1]} alt={match.AwayTeam} class="flag" />
							<h3 class="home-team">{match.AwayTeam}</h3>
						</div>
					</div>
					<div class="time-area">
						<div class="time">
							<h4 class="month">{new Date(match.DateUtc).toString().split(' ')[1]}</h4>
							<h4 class="day">{new Date(match.DateUtc).toString().split(' ')[0]}</h4>
							<h4 class="date">{new Date(match.DateUtc).toString().split(' ')[2]}</h4>
						</div>
						<h4 class="match-time">
							{new Date(match.DateUtc).toLocaleTimeString().replace(':00:00', ':00')}
						</h4>
					</div>
				</div>
			{/each}
		</div>
	</div>
	<div class="scroll-top">
		<img src={arrow} alt="arrow" />
	</div>
</div>

<style>
	#schedule {
		font-size: 1.6rem;
		background: var(--bg);
	}

	::-webkit-scrollbar {
		width: 1.2rem;
	}

	::-webkit-scrollbar-track {
		background: var(--scrollbar-bg);
		box-shadow: inset 0 0 0.3rem var(--bg);
	}

	::-webkit-scrollbar-thumb {
		background: #888;
		border-radius: 1.2rem;
	}

	::-webkit-scrollbar-thumb:hover {
		background: #555;
	}

	.container-custom {
		max-width: 144rem;
		padding: 0 2rem;
		margin: 0 auto;
	}

	.tab-link {
		margin: 3rem 2rem 3rem 0;
		display: inline-flex;
	}

	.tab-link a {
		color: var(--white);
		background: var(--btn-bg);
		padding: 0.6rem 1.5rem;
		border-radius: 1.5rem;
		cursor: pointer;
	}

	.section-heading {
		font-size: 3rem;
		margin: 3rem 0;
	}

	.matchs,
	.matchs-by-group {
		padding: 2rem 0;
		display: grid;
		grid-template-columns: repeat(auto-fit, minmax(30rem, 1fr));
		gap: 2rem;
	}

	.match {
		background: var(--card-bg);
		position: relative;
		padding: 1.5rem;
		border-radius: 0.5rem;
		box-shadow: 0 0 0.2rem 0.1rem var(--shadow);
		font-size: 1.6rem;
		font-weight: bold;
		color: var(--text-dark);
	}
	.match:hover {
		box-shadow: 0 0 0.2rem 0.1rem rgba(235, 240, 250, 0.9);
		background: #c2c2b6;
	}
	.match-info {
		display: flex;
		justify-content: space-between;
	}

	.badge {
		position: absolute;
		right: -1rem;
		top: -1rem;
		display: inline-flex;
		width: 3rem;
		height: 3rem;
		background: var(--card-bg);
		color: var(--badge-text);
		box-shadow: 0 0 0.2rem 0.1rem var(--card-bg);
		justify-content: center;
		align-items: center;
		border-radius: 50%;
		margin-left: 1rem;
	}

	.flags {
		padding: 3rem 0 1rem 0;
		display: grid;
		grid-template-columns: 3fr 1fr 3fr;
		align-items: center;
		gap: 1rem;
		text-align: center;
	}

	.flag {
		width: 5rem;
	}

	.vs {
		font-size: 3rem;
	}

	.time-area {
		padding: 2rem 0 0 0;
		display: flex;
		justify-content: space-between;
		align-items: center;
	}

	.time {
		display: inline-flex;
		gap: 1rem;
	}

	.scroll-top {
		opacity: 0;
		transform: translateY(-10rem);
		position: fixed;
		right: 0.5rem;
		bottom: 2rem;
		background: var(--bg);
		width: 4rem;
		height: 4rem;
		border-radius: 50%;
		display: flex;
		align-items: center;
		justify-content: center;
		box-shadow: 0 0 0.1rem var(--badge-text);
		transition: all 0.5s ease-in-out;
		cursor: pointer;
		z-index: 100;
	}

	/*
.scroll-top.active {
    opacity: 1;
    transform: translateY(0);
}
*/

	.scroll-top img {
		width: 2rem;
		transform: rotate(180deg);
	}

	@media (max-width: 382px) {
		.tab-link {
			margin: 2rem 0 0 0;
		}
		.matchs,
		.matchs-by-group {
			grid-template-columns: repeat(auto-fit, minmax(25rem, 1fr));
		}
	}
</style>
