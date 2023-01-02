<script lang="ts">
	import '../../styles.css';
	import arrow from '$lib/images/arrow.png';
	import { browser } from '$app/environment';
	import { onMount } from 'svelte';
	import Swal from 'sweetalert2';
	import 'sweetalert2/src/sweetalert2.scss';

	// "Country" : https://flagcdn.com/[COUNTRY_CODE].svg
	let flag_urls = {
		Argentina: 'https://flagcdn.com/ar.svg',
		Australia: 'https://flagcdn.com/au.svg',
		Belgium: 'https://flagcdn.com/be.svg',
		Brazil: 'https://flagcdn.com/br.svg',
		Cameron: 'https://flagcdn.com/cm.svg',
		Canada: 'https://flagcdn.com/ca.svg',
		Croatia: 'https://flagcdn.com/hr.svg',
		'Costa Rica': 'https://flagcdn.com/cr.svg',
		Denmark: 'https://flagcdn.com/dk.svg',
		Ecuador: 'https://flagcdn.com/ec.svg',
		England: 'https://flagcdn.com/gb-eng.svg',
		France: 'https://flagcdn.com/fr.svg',
		Germany: 'https://flagcdn.com/de.svg',
		Ghana: 'https://flagcdn.com/gh.svg',
		Iran: 'https://flagcdn.com/ir.svg',
		Japan: 'https://flagcdn.com/jp.svg',
		Mexico: 'https://flagcdn.com/mx.svg',
		Morocco: 'https://flagcdn.com/ma.svg',
		Netherlands: 'https://flagcdn.com/nl.svg',
		Poland: 'https://flagcdn.com/pl.svg',
		Portugal: 'https://flagcdn.com/pt.svg',
		Qatar: 'https://flagcdn.com/qa.svg',
		'Saudi Arabia': 'https://flagcdn.com/sa.svg',
		Senegal: 'https://flagcdn.com/sn.svg',
		Serbia: 'https://flagcdn.com/rs.svg',
		'South Korea': 'https://flagcdn.com/kr.svg',
		Spain: 'https://flagcdn.com/es.svg',
		Switzerland: 'https://flagcdn.com/ch.svg',
		Tunisia: 'https://flagcdn.com/tn.svg',
		'United States': 'https://flagcdn.com/us.svg',
		Uruguay: 'https://flagcdn.com/uy.svg'
	};

	async function navigateBook(id: number) {
		const selected = matches.find(x => x.id == id);		

		if (selected) {
			if (new Date(selected.time) < new Date()) {
				await Swal.fire('Sorry!', 'Reservation is closed for this match', 'info');
				return;
			}
		}

		let _token;
		if (browser) {
			_token = window.localStorage.getItem('token');
		}
		if (_token) {
			window.location.replace('/reservation/' + id);
		} else {
			await Swal.fire('Invalid!', 'You need to log in to reserve a match.', 'error');
		}
	}

	let token = '';
	onMount(async () => {
		let _token;
		let _role;
		if (browser) {
			_token = window.localStorage.getItem('token');
			_role = window.localStorage.getItem('role');
		}

		if (_token) {
			if (_role == 'Manager') {
				window.location.replace('/manager/match/list');
			} else if (_role == 'Admin') {
				window.location.replace('/admin/list');
			}
			token = _token;
		}
		await getMatches();
	});

	let matches: {
		id: number;
		homeTeam: string;
		awayTeam: string;
		stadium: string;
		time: string;
		stadiumCapacity: number;
		emptySeats: number;
		referee: string;
		firstLinesman: string;
		secondLinesman: string;
	}[] = [];
	async function getMatches() {
		const response = await fetch('https://localhost:7123/api/matches', {
			method: 'GET',
			headers: {
				'Content-Type': 'application/json'
			}
		});
		if (response.ok) {
			const data = await response.json();
			matches = data;
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
		<div class="matchs" id="match-date">
			{#each matches as match}
				<!-- svelte-ignore a11y-click-events-have-key-events -->
				<div class="match" on:click={() => navigateBook(match.id)}>
					<div class="match-info">
						<h4 class="group">{match.stadium}</h4>
						<h4>
							Seats: {match.emptySeats}/{match.stadiumCapacity}<span class="badge">{match.id}</span>
						</h4>
					</div>
					<div class="flags">
						<div class="home-flag">
							<img
								src={flag_urls[match.homeTeam]}
								style="width:60px"
								alt={match.homeTeam}
								class="flag"
							/>
							<h3 class="home-team">{match.homeTeam}</h3>
						</div>
						<span class="vs"> VS </span>
						<div class="away-flag">
							<img
								src={flag_urls[match.awayTeam]}
								style="width:60px"
								alt={match.awayTeam}
								class="flag"
							/>
							<h3 class="home-team">{match.awayTeam}</h3>
						</div>
					</div>
					<div class="time-area">
						<div class="time">
							<h4 class="month">{new Date(match.time).toString().split(' ')[1]}</h4>
							<h4 class="day">{new Date(match.time).toString().split(' ')[2]}</h4>
							<h4 class="date">
								{new Date(match.time).toLocaleTimeString().replace(':00:00', ':00')}
							</h4>
						</div>
						<h4 class="match-time">
							{match.referee}
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

	.matchs {
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

	.scroll-top img {
		width: 2rem;
		transform: rotate(180deg);
	}

	@media (max-width: 382px) {
		.matchs {
			grid-template-columns: repeat(auto-fit, minmax(25rem, 1fr));
		}
	}
</style>
