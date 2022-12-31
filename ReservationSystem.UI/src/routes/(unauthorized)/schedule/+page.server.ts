import json from './fifa-world-cup.json';

export async function load () {
    return {
        status: 200,
        matches: json
    };
}