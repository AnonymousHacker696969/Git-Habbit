// Initialize application when DOM is fully loaded
document.addEventListener('DOMContentLoaded', function() {
    // DOMContentLoaded event fires when HTML is completely parsed
    initApp(); // Call the main initialization function
});

// Global state variables
let currentDate = new Date(2025, 0, 1); // January 1, 2025 (month is 0-indexed)
let habits = []; // Array to store all habits
let calendarData = {}; // Object to store completion data for each date
let currentDayIndex = 1; // Counter for current day (starts at 1)

// Initialize the application
function initApp() {
    // Set up theme toggle functionality
    setupThemeToggle();
    
    // Initialize habits array with default habits
    initializeHabits();
    
    // Initialize calendar structure
    initializeCalendar();
    
    // Render everything to the page
    renderHabits(); // Display habits
    renderCalendar(); // Display calendar
    updateDateDisplay(); // Update date text
    
    // Set up event listeners for buttons
    document.getElementById('next-day-btn').addEventListener('click', goToNextDay);
}

// Set up theme toggle functionality
function setupThemeToggle() {
    const themeToggle = document.getElementById('theme-toggle'); // Get theme button
    const themeIcon = themeToggle.querySelector('i'); // Get icon inside button
    
    // Check for saved theme in localStorage
    const savedTheme = localStorage.getItem('habitTrackerTheme');
    // Check if user prefers dark mode
    const prefersDark = window.matchMedia('(prefers-color-scheme: dark)').matches;
    
    // Apply dark theme if saved preference is dark OR no preference but system prefers dark
    if (savedTheme === 'dark' || (!savedTheme && prefersDark)) {
        document.documentElement.setAttribute('data-theme', 'dark'); // Set dark theme attribute
        themeIcon.className = 'fas fa-sun'; // Change icon to sun
        themeToggle.innerHTML = '<i class="fas fa-sun"></i> Light Mode'; // Update button text
    }
    
    // Add click event listener to theme toggle button
    themeToggle.addEventListener('click', () => {
        const currentTheme = document.documentElement.getAttribute('data-theme');
        
        // If currently dark, switch to light
        if (currentTheme === 'dark') {
            document.documentElement.removeAttribute('data-theme'); // Remove dark theme
            themeIcon.className = 'fas fa-moon'; // Change icon to moon
            themeToggle.innerHTML = '<i class="fas fa-moon"></i> Dark Mode'; // Update text
            localStorage.setItem('habitTrackerTheme', 'light'); // Save preference
        } else {
            // If currently light, switch to dark
            document.documentElement.setAttribute('data-theme', 'dark'); // Set dark theme
            themeIcon.className = 'fas fa-sun'; // Change icon to sun
            themeToggle.innerHTML = '<i class="fas fa-sun"></i> Light Mode'; // Update text
            localStorage.setItem('habitTrackerTheme', 'dark'); // Save preference
        }
    });
}

// Initialize default habits
function initializeHabits() {
    // Define 5 default habits with properties
    habits = [
        {
            id: 1, // Unique identifier
            name: "Morning Exercise", // Habit name
            colorClass: "habit-1", // CSS class for color
            streak: 0, // Current streak count
            completedToday: false, // Whether completed today
            history: {} // Object to track completion history
        },
        {
            id: 2,
            name: "Read 30 Minutes",
            colorClass: "habit-2",
            streak: 0,
            completedToday: false,
            history: {}
        },
        {
            id: 3,
            name: "Meditate",
            colorClass: "habit-3",
            streak: 0,
            completedToday: false,
            history: {}
        },
        {
            id: 4,
            name: "Drink 8 Glasses of Water",
            colorClass: "habit-4",
            streak: 0,
            completedToday: false,
            history: {}
        },
        {
            id: 5,
            name: "No Late-Night Snacking",
            colorClass: "habit-5",
            streak: 0,
            completedToday: false,
            history: {}
        }
    ];
    
    // Initialize calendar data for entire year
    const startDate = new Date(2025, 0, 1); // January 1, 2025
    const endDate = new Date(2025, 11, 31); // December 31, 2025
    
    // Create an entry for each day of the year
    for (let date = new Date(startDate); date <= endDate; date.setDate(date.getDate() + 1)) {
        const dateString = formatDate(date); // Format as YYYY-MM-DD
        calendarData[dateString] = { date: new Date(date), habits: {} }; // Initialize with empty habits object
    }
    
    // Load saved data from localStorage if available
    loadSavedData();
}

// Initialize calendar structure in the DOM
function initializeCalendar() {
    // Get container for month columns
    const monthsContainer = document.querySelector('.calendar-months');
    monthsContainer.innerHTML = ''; // Clear any existing content
    
    // Create columns for each month (January to December)
    for (let month = 0; month < 12; month++) {
        // Create container for this month
        const monthColumn = document.createElement('div');
        monthColumn.className = 'month-column';
        
        // Create month name label
        const monthName = document.createElement('div');
        monthName.className = 'month-name';
        // Get abbreviated month name (Jan, Feb, etc.)
        monthName.textContent = new Date(2025, month, 1).toLocaleString('default', { month: 'short' });
        
        // Create grid for days
        const calendarGrid = document.createElement('div');
        calendarGrid.className = 'calendar-grid';
        
        // Calculate which day of week the 1st falls on (0 = Sunday, 1 = Monday, etc.)
        const firstDayOfMonth = new Date(2025, month, 1);
        const startingDay = firstDayOfMonth.getDay();
        
        // Add empty cells for days before the 1st (to align grid)
        for (let i = 0; i < startingDay; i++) {
            const emptyCell = document.createElement('div');
            emptyCell.className = 'day-cell empty';
            calendarGrid.appendChild(emptyCell);
        }
        
        // Get number of days in this month
        const daysInMonth = new Date(2025, month + 1, 0).getDate();
        
        // Create a cell for each day of the month
        for (let day = 1; day <= daysInMonth; day++) {
            const dayCell = document.createElement('div');
            dayCell.className = 'day-cell';
            // Store date as data attribute for easy lookup
            dayCell.dataset.date = formatDate(new Date(2025, month, day));
            calendarGrid.appendChild(dayCell);
        }
        
        // Add month name and grid to column
        monthColumn.appendChild(monthName);
        monthColumn.appendChild(calendarGrid);
        // Add column to container
        monthsContainer.appendChild(monthColumn);
    }
}

// Render habits in the UI
function renderHabits() {
    const habitsContainer = document.querySelector('.habits-container');
    habitsContainer.innerHTML = ''; // Clear existing habits
    
    let totalStreak = 0; // Initialize total streak counter
    
    // Loop through each habit and create its card
    habits.forEach(habit => {
        totalStreak += habit.streak; // Add to total streak
        
        // Create habit card container
        const habitCard = document.createElement('div');
        habitCard.className = 'habit-card';
        
        // Create checkbox for completion
        const checkbox = document.createElement('input');
        checkbox.type = 'checkbox';
        checkbox.className = 'habit-checkbox';
        checkbox.id = `habit-${habit.id}`;
        checkbox.checked = habit.completedToday; // Set checked state
        // Add event listener for toggling completion
        checkbox.addEventListener('change', () => toggleHabitCompletion(habit.id));
        
        // Create container for habit info
        const habitInfo = document.createElement('div');
        habitInfo.className = 'habit-info';
        
        // Create habit name element
        const habitName = document.createElement('div');
        habitName.className = 'habit-name';
        habitName.textContent = habit.name;
        
        // Create streak display element
        const habitStreak = document.createElement('div');
        habitStreak.className = 'habit-streak';
        habitStreak.innerHTML = `<i class="fas fa-fire"></i> Current streak: ${habit.streak} days`;
        
        // Add name and streak to info container
        habitInfo.appendChild(habitName);
        habitInfo.appendChild(habitStreak);
        
        // Create progress bar container
        const progressContainer = document.createElement('div');
        progressContainer.className = 'progress-container';
        
        // Create label for progress bar
        const progressLabel = document.createElement('div');
        progressLabel.className = 'progress-label';
        
        // Calculate progress percentage (capped at 100%)
        const progressPercentage = Math.min(100, (habit.streak / 30) * 100);
        
        // Set label text with percentage
        progressLabel.innerHTML = `<span>Progress</span><span>${Math.round(progressPercentage)}%</span>`;
        
        // Create progress bar background
        const progressBar = document.createElement('div');
        progressBar.className = 'progress-bar';
        
        // Create progress fill (the colored part)
        const progressFill = document.createElement('div');
        progressFill.className = 'progress-fill';
        progressFill.style.width = `${progressPercentage}%`; // Set width based on percentage
        progressFill.style.backgroundColor = `var(--${habit.colorClass})`; // Use habit's color
        
        // Add fill to bar
        progressBar.appendChild(progressFill);
        
        // Add label and bar to container
        progressContainer.appendChild(progressLabel);
        progressContainer.appendChild(progressBar);
        
        // Add all elements to habit card
        habitCard.appendChild(checkbox);
        habitCard.appendChild(habitInfo);
        habitCard.appendChild(progressContainer);
        
        // Add habit card to container
        habitsContainer.appendChild(habitCard);
    });
    
    // Update total streak display
    document.getElementById('total-streak').textContent = totalStreak;
    // Update current day display
    document.getElementById('current-day-display').textContent = currentDayIndex;
}

// Render calendar with activity data
function renderCalendar() {
    // Get all day cells (excluding empty placeholder cells)
    const dayCells = document.querySelectorAll('.day-cell:not(.empty)');
    
    // Reset all cells to default state
    dayCells.forEach(cell => {
        cell.style.backgroundColor = ''; // Clear background color
        cell.classList.remove('today'); // Remove today class
        cell.title = ''; // Clear tooltip
    });
    
    // Mark the current date on calendar
    const todayString = formatDate(currentDate);
    const todayCell = document.querySelector(`.day-cell[data-date="${todayString}"]`);
    if (todayCell) {
        todayCell.classList.add('today'); // Add today class for styling
    }
    
    // Color cells based on habit completion data
    Object.keys(calendarData).forEach(dateString => {
        const cell = document.querySelector(`.day-cell[data-date="${dateString}"]`);
        if (!cell) return; // Skip if cell doesn't exist (shouldn't happen)
        
        const dayData = calendarData[dateString];
        // Count how many habits were completed on this day
        const completedHabits = Object.values(dayData.habits).filter(completed => completed).length;
        
        // Determine color intensity based on number of completed habits
        let intensity = 0; // Default: no activity
        if (completedHabits > 0) {
            intensity = 1; // Low activity
            if (completedHabits >= 3) intensity = 2; // Medium activity
            if (completedHabits >= 5) intensity = 3; // High activity
        }
        
        // Apply color if there was any activity
        if (intensity > 0) {
            // Determine which color to use based on habits completed
            // Uses the color of the habit at index (completedHabits - 1)
            const habitColor = habits[Math.min(completedHabits - 1, habits.length - 1)].colorClass;
            const colorVar = `var(--${habitColor})`; // CSS variable name
            
            // Calculate opacity based on intensity (more habits = more opaque)
            let opacity = 0.3; // Low intensity
            if (intensity === 2) opacity = 0.6; // Medium intensity
            if (intensity === 3) opacity = 1; // High intensity
            
            // Get the actual color value from CSS
            const rgb = getComputedStyle(document.documentElement)
                .getPropertyValue(`--${habitColor}`)
                .trim();
            
            // Convert hex color to rgba with opacity
            if (rgb.startsWith('#')) {
                // Parse hex color (#RRGGBB)
                const r = parseInt(rgb.slice(1, 3), 16);
                const g = parseInt(rgb.slice(3, 5), 16);
                const b = parseInt(rgb.slice(5, 7), 16);
                // Apply with calculated opacity
                cell.style.backgroundColor = `rgba(${r}, ${g}, ${b}, ${opacity})`;
            } else {
                // If not hex, use as-is (could be rgba already)
                cell.style.backgroundColor = rgb;
            }
        }
        
        // Create tooltip with date and completion info
        const date = new Date(dateString);
        const formattedDate = date.toLocaleDateString('en-US', { 
            weekday: 'long', 
            year: 'numeric', 
            month: 'long', 
            day: 'numeric' 
        });
        
        // Set tooltip text based on completion count
        if (completedHabits > 0) {
            cell.title = `${formattedDate}\n${completedHabits} habit${completedHabits !== 1 ? 's' : ''} completed`;
        } else {
            cell.title = `${formattedDate}\nNo habits completed`;
        }
    });
}

// Toggle habit completion for current day
function toggleHabitCompletion(habitId) {
    // Find the habit by ID
    const habit = habits.find(h => h.id === habitId);
    if (!habit) return; // Exit if habit not found
    
    // Format current date as string for use as key
    const dateString = formatDate(currentDate);
    
    // Toggle completion status
    habit.completedToday = !habit.completedToday;
    
    // Ensure calendar data exists for today
    if (!calendarData[dateString]) {
        calendarData[dateString] = { date: new Date(currentDate), habits: {} };
    }
    
    // Update calendar data with new completion status
    calendarData[dateString].habits[habitId] = habit.completedToday;
    
    // Update streak logic
    if (habit.completedToday) {
        // If habit was just checked (completed today)
        const yesterday = new Date(currentDate);
        yesterday.setDate(yesterday.getDate() - 1); // Get yesterday's date
        const yesterdayString = formatDate(yesterday);
        
       
