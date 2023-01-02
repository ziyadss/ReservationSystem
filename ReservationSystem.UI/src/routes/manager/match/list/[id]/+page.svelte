<script lang="ts">
	import { page } from '$app/stores';
	import { onMount } from 'svelte';
	import { browser } from '$app/environment';
	import Swal from 'sweetalert2';
	import seat from '../../../../../lib/images/cinema-seat.svg';
	import seatReserved from '../../../../../lib/images/seat-reserved.svg';

	const id = $page.params.id;
	let match = {
		id: 0,
		homeTeam: 'string',
		awayTeam: 'string',
		stadium: 'string',
		time: '2023-01-02T01:36:38.458Z',
		stadiumCapacity: 0,
		emptySeats: 0,
		referee: 'string',
		firstLinesman: 'string',
		secondLinesman: 'string',
		availableSeats: [
			{
				ticketNumber: 'string',
				row: 0,
				column: 0
			}
		]
	};
	let stadium = {
		name: 'string',
		capacity: 0,
		rows: 0,
		columns: 0,
		matches: [
			{
				id: 0,
				homeTeam: 'string',
				awayTeam: 'string',
				stadiumName: 'string',
				time: '2023-01-02T01:42:28.305Z'
			}
		]
	};
	let token: string;

	onMount(async () => {
		if (browser) {
			token = window.localStorage.getItem('token')!;
		}
		const response = await fetch('https://localhost:7123/api/matches/' + id);
		if (response.ok) {
			match = await response.json();
			console.log('available seat: ' + JSON.stringify(match));
			const response2 = await fetch('https://localhost:7123/api/stadiums/' + match.stadium);
			if (response2.ok) {
				stadium = await response2.json();
			} else {
				await Swal.fire({
					title: 'Error!',
					text: 'Error in loading stadium, please try again',
					icon: 'error',
					confirmButtonText: 'OK'
				});
				window.location.replace('/schedule');
			}
		} else {
			await Swal.fire({
				title: 'Error!',
				text: 'Error in loading matches, please try again',
				icon: 'error',
				confirmButtonText: 'OK'
			});
			window.location.replace('/schedule');
		}
	});
</script>

<div class="container">
	<div class="col p-3 my-5 shadow-sm rounded-5" style="background-color: #f7f7f7; min-width:800px;">
		<h1 class="title pb-3">Match: {match.homeTeam} - {match.awayTeam} : {match.stadium}</h1>
		<h2 class="title pb-3">Availble seats: {match.availableSeats.length}/{stadium.capacity}</h2>
		{#each { length: stadium.rows } as _, i}
			<div class="row">
				{#each { length: stadium.columns } as _, j}
					<div class="col">
						{#if match.availableSeats.find((seat) => seat.row == i && seat.column == j)}
							<!-- svelte-ignore a11y-click-events-have-key-events -->
							<img src={seat} alt="seat" class="seat_empty" id="seat_{i}_{j}" />
						{:else}
							<!-- svelte-ignore a11y-click-events-have-key-events -->
							<img src={seatReserved} alt="seat" class="seat" />
						{/if}
					</div>
				{/each}
			</div>
		{/each}
	</div>
</div>
