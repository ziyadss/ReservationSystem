<script lang="ts">
	import { page } from '$app/stores';
	import { onMount } from 'svelte';
	import Swal from 'sweetalert2';
	import 'sweetalert2/src/sweetalert2.scss';
	import seat from '../../../../lib/images/cinema-seat.svg';
	import seatReserved from '../../../../lib/images/seat-reserved.svg';
	import seatClicked from '../../../../lib/images/seat-clicked.svg';
	import { browser } from '$app/environment';

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

	// console.log(params.id);
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
	let ticketNumbersList: Array<string>;
	console.log('available seats ely gyly: ' + JSON.stringify(match.availableSeats));
	function reserveSeat(row: number, column: number) {
		if (document.getElementById('seat_' + row + '_' + column) != null) {
			let bikeImage = document.getElementById('seat_' + row + '_' + column) as HTMLImageElement;
			if (ticketNumbersList == undefined) ticketNumbersList = new Array<string>();
			let choosen: boolean =
				ticketNumbersList.find(
					(ticketNumber: string) =>
						ticketNumber ==
						match.availableSeats.find((seat) => seat.row == row && seat.column == column)
							?.ticketNumber
				) != undefined;
			if (!choosen) {
				console.log(row, column);
				console.log('not chosen');
				bikeImage!.src = seatClicked;
				ticketNumbersList.push(
					match.availableSeats.find((seat) => seat.row == row && seat.column == column)!
						.ticketNumber
				);
			} else if (choosen) {
				console.log('chosen');
				bikeImage!.src = seat;
				ticketNumbersList = ticketNumbersList.filter(
					(ticketNumber: string) =>
						ticketNumber !=
						match.availableSeats.find((seat) => seat.row == row && seat.column == column)
							?.ticketNumber
				);
			}
		}
	}

	async function reservationRequest() {
		const response = await fetch('https://localhost:7123/api/reservations/book', {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json',
				Authorization: 'Bearer ' + token
			},
			body: JSON.stringify({
				ticketNumbers: ticketNumbersList
			})
		});
		console.log(
			'body sent:' +
				JSON.stringify({
					ticketNumbers: ticketNumbersList
				})
		);
		if (response.ok) {
			await Swal.fire({
				title: 'Success!',
				text: 'Your reservation has been made successfully',
				icon: 'success',
				confirmButtonText: 'OK'
			});
			window.location.replace('/profile');
		} else {
			await Swal.fire({
				title: 'Error!',
				text: 'Error in making reservation, please try again',
				icon: 'error',
				confirmButtonText: 'OK'
			});
		}
	}
</script>

<div class="container" id="reservationPage">
	<div class="row p-5">
		<h1 class="pb-2 border-bottom">Reservation</h1>
		<div class="row p-5 justify-content-center">
			<form on:submit={reservationRequest}>
				<div class="col p-3 shadow-sm rounded-5" style="background-color: #f7f7f7;">
					<h1 class="title">Step 1</h1>
					<div class="form-outline py-2">
						<label for="match">Pick your match</label>
						<input
							type="text"
							class="form-control"
							id="match"
							value="{match.homeTeam} VS. {match.awayTeam} in {match.stadium}"
							disabled
						/>
					</div>
				</div>
				<div
					class="col p-3 my-5 shadow-sm rounded-5"
					style="background-color: #f7f7f7; min-width:800px;"
				>
					<h1 class="title">Step 2</h1>
					<p>Pick your seats</p>
					{#each { length: stadium.rows } as _, i}
						<div class="row">
							{#each { length: stadium.columns } as _, j}
								<div class="col">
									{#if match.availableSeats.find((seat) => seat.row == i && seat.column == j)}
										<!-- svelte-ignore a11y-click-events-have-key-events -->
										<img
											src={seat}
											alt="seat"
											class="seat_empty"
											id="seat_{i}_{j}"
											on:click={() => {
												reserveSeat(i, j);
											}}
										/>
									{:else}
										<!-- svelte-ignore a11y-click-events-have-key-events -->
										<img src={seatReserved} alt="seat" class="seat" />
									{/if}
								</div>
							{/each}
						</div>
					{/each}
				</div>
				<div class="col p-3 shadow-sm rounded-5" style="background-color: #f7f7f7;">
					<h1 class="title">Step 3</h1>
					<div class="form-outline py-2">
						<label for="match">Enter Your Credit Card Number</label>
						<input class="input-element" />
					</div>
				</div>
				<button class="btn" style="font-size: 1.5rem;" type="submit">Confirm</button>
			</form>
		</div>
	</div>
</div>
