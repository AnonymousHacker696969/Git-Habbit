:root {
    /* CSS custom properties (variables) for light theme */
    --bg-color: #ffffff; /* Main background color */
    --text-color: #333333; /* Main text color */
    --container-bg: #f8f9fa; /* Container background */
    --border-color: #dee2e6; /* Border color */
    --primary-color: #4a6fa5; /* Primary color for buttons, accents */
    --secondary-color: #6c757d; /* Secondary color for less important text */
    --success-color: #28a745; /* Success/green color */
    --danger-color: #dc3545; /* Danger/red color */
    --box-shadow: 0 4px 12px rgba(0, 0, 0, 0.08); /* Default shadow */
    --calendar-cell: #ebedf0; /* Default calendar cell color (GitHub style) */
    --habit-1: #40c463; /* Color for habit 1 */
    --habit-2: #30a14e; /* Color for habit 2 */
    --habit-3: #216e39; /* Color for habit 3 */
    --habit-4: #9be9a8; /* Color for habit 4 */
    --habit-5: #d1f7c4; /* Color for habit 5 */
}

[data-theme="dark"] {
    /* Override variables for dark theme */
    --bg-color: #1a1a2e; /* Dark background */
    --text-color: #e6e6e6; /* Light text */
    --container-bg: #16213e; /* Darker container */
    --border-color: #0f3460; /* Dark border */
    --primary-color: #4cc9f0; /* Brighter primary */
    --secondary-color: #a9a9a9; /* Muted secondary */
    --success-color: #4ade80; /* Brighter success */
    --danger-color: #f87171; /* Softer danger */
    --box-shadow: 0 4px 12px rgba(0, 0, 0, 0.25); /* Stronger shadow */
    --calendar-cell: #2d3748; /* Dark calendar cell */
    /* Adjusted habit colors for dark theme */
    --habit-1: #26a641;
    --habit-2: #0e8a16;
    --habit-3: #006d32;
    --habit-4: #39d353;
    --habit-5: #9be9a8;
}

* {
    /* Universal selector - applies to ALL elements */
    margin: 0; /* Remove default margin */
    padding: 0; /* Remove default padding */
    box-sizing: border-box; /* Include padding/border in element's total width/height */
    transition: background-color 0.3s, color 0.3s; /* Smooth transitions for theme changes */
}

body {
    /* Styles for the body element */
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; /* Font stack */
    background-color: var(--bg-color); /* Use CSS variable */
    color: var(--text-color); /* Use CSS variable */
    line-height: 1.6; /* Better line spacing for readability */
    padding: 20px; /* Space around edges */
    min-height: 100vh; /* At least full viewport height */
}

.container {
    /* Main container for all content */
    max-width: 1100px; /* Maximum width on large screens */
    margin: 0 auto; /* Center horizontally */
    background-color: var(--container-bg); /* Use CSS variable */
    border-radius: 12px; /* Rounded corners */
    box-shadow: var(--box-shadow); /* Use CSS variable */
    padding: 25px; /* Internal spacing */
    border: 1px solid var(--border-color); /* Border with CSS variable */
}

header {
    /* Header styles */
    margin-bottom: 30px; /* Space below header */
    padding-bottom: 15px; /* Space at bottom of header */
    border-bottom: 2px solid var(--border-color); /* Bottom border */
}

.header-content {
    /* Container for header title and controls */
    display: flex; /* Use flexbox for layout */
    justify-content: space-between; /* Space between title and controls */
    align-items: center; /* Vertically center items */
    flex-wrap: wrap; /* Allow wrapping on small screens */
    gap: 15px; /* Gap between flex items */
}

h1 {
    /* Main heading */
    color: var(--primary-color); /* Use CSS variable */
    font-size: 2.2rem; /* Large font size */
    display: flex; /* Flexbox to align icon and text */
    align-items: center; /* Vertically center */
    gap: 10px; /* Space between icon and text */
}

h1 i {
    /* Icon inside h1 */
    font-size: 1.8rem; /* Slightly smaller than text */
}

.subtitle {
    /* Subtitle text */
    color: var(--secondary-color); /* Use CSS variable */
    font-size: 1.1rem; /* Medium font size */
    margin-top: 5px; /* Small space above */
}

.controls {
    /* Container for control buttons */
    display: flex; /* Flexbox layout */
    gap: 15px; /* Space between buttons */
    flex-wrap: wrap; /* Allow wrapping */
}

.theme-btn, .next-day-btn {
    /* Styles for both button types */
    padding: 10px 20px; /* Internal spacing */
    border: none; /* Remove default border */
    border-radius: 8px; /* Rounded corners */
    font-weight: 600; /* Bold text */
    cursor: pointer; /* Pointer cursor on hover */
    display: flex; /* Flexbox for icon+text alignment */
    align-items: center; /* Vertically center */
    gap: 8px; /* Space between icon and text */
    font-size: 0.95rem; /* Font size */
    transition: transform 0.2s, opacity 0.2s; /* Animation on hover */
}

.theme-btn:hover, .next-day-btn:hover {
    /* Hover effects for buttons */
    transform: translateY(-2px); /* Move up slightly */
    opacity: 0.9; /* Slightly transparent */
}

.theme-btn {
    /* Specific styles for theme button */
    background-color: var(--primary-color); /* Use CSS variable */
    color: white; /* White text */
}

.next-day-btn {
    /* Specific styles for next day button */
    background-color: var(--success-color); /* Green background */
    color: white; /* White text */
}

section {
    /* Styles for all sections */
    margin-bottom: 35px; /* Space below sections */
    padding: 20px; /* Internal spacing */
    border-radius: 10px; /* Rounded corners */
    background-color: var(--bg-color); /* Use CSS variable */
    border: 1px solid var(--border-color); /* Border */
}

.section-header {
    /* Header within sections */
    display: flex; /* Flexbox layout */
    justify-content: space-between; /* Space between title and date */
    align-items: center; /* Vertically center */
    margin-bottom: 20px; /* Space below */
    flex-wrap: wrap; /* Allow wrapping */
    gap: 15px; /* Gap between items */
}

h2 {
    /* Section headings */
    color: var(--primary-color); /* Use CSS variable */
    font-size: 1.6rem; /* Medium font size */
    display: flex; /* Flexbox for icon alignment */
    align-items: center; /* Vertically center */
    gap: 10px; /* Space between icon and text */
}

.current-date {
    /* Container for date and streak */
    display: flex; /* Flexbox layout */
    align-items: center; /* Vertically center */
    gap: 15px; /* Space between date and streak */
    font-weight: 600; /* Bold text */
}

.streak-summary {
    /* Container for streak count */
    background-color: var(--primary-color); /* Use CSS variable */
    color: white; /* White text */
    padding: 8px 15px; /* Internal spacing */
    border-radius: 20px; /* Pill shape */
    display: flex; /* Flexbox layout */
    align-items: center; /* Vertically center */
    gap: 8px; /* Space between number and text */
}

.streak-count {
    /* The actual streak number */
    font-weight: bold; /* Bold */
    font-size: 1.2rem; /* Larger font */
}

.calendar-container {
    /* Container for calendar */
    margin-top: 20px; /* Space above */
}

.calendar-months {
    /* Container for month columns */
    display: flex; /* Flexbox layout */
    flex-wrap: wrap; /* Allow wrapping */
    gap: 15px; /* Space between months */
    margin-bottom: 20px; /* Space below */
}

.month-column {
    /* Individual month column */
    display: flex; /* Flexbox layout */
    flex-direction: column; /* Stack vertically */
    gap: 3px; /* Small gap between cells */
}

.month-name {
    /* Month name label */
    font-size: 0.85rem; /* Small font */
    margin-bottom: 5px; /* Space below */
    color: var(--secondary-color); /* Use CSS variable */
    text-align: center; /* Center text */
}

.calendar-grid {
    /* Grid of day cells */
    display: grid; /* CSS Grid layout */
    grid-template-rows: repeat(7, 1fr); /* 7 rows (for days of week) */
    gap: 3px; /* Small gap between cells */
}

.day-cell {
    /* Individual day cell */
    width: 15px; /* Fixed width */
    height: 15px; /* Fixed height */
    background-color: var(--calendar-cell); /* Use CSS variable */
    border-radius: 2px; /* Slightly rounded corners */
    position: relative; /* For positioning if needed */
}

.day-cell.today {
    /* Style for current day */
    border: 2px solid var(--primary-color); /* Colored border */
}

.calendar-legend {
    /* Legend for calendar colors */
    display: flex; /* Flexbox layout */
    align-items: center; /* Vertically center */
    justify-content: flex-end; /* Align to right */
    gap: 8px; /* Space between items */
    margin-top: 15px; /* Space above */
}

.legend-color {
    /* Color squares in legend */
    width: 15px; /* Same as day cells */
    height: 15px; /* Same as day cells */
    border-radius: 2px; /* Same as day cells */
}

/* Intensity color classes - different shades for activity levels */
.intensity-0 { background-color: var(--calendar-cell); } /* No activity */
.intensity-1 { background-color: var(--habit-4); } /* Low activity */
.intensity-2 { background-color: var(--habit-1); } /* Medium activity */
.intensity-3 { background-color: var(--habit-3); } /* High activity */

.legend-label {
    /* Labels in legend */
    font-size: 0.85rem; /* Small font */
    color: var(--secondary-color); /* Use CSS variable */
}

.section-info {
    /* Informational text in sections */
    color: var(--secondary-color); /* Use CSS variable */
    margin-bottom: 20px; /* Space below */
    font-style: italic; /* Italic text */
}

.habits-container {
    /* Container for habit cards */
    display: flex; /* Flexbox layout */
    flex-direction: column; /* Stack vertically */
    gap: 15px; /* Space between cards */
}

.habit-card {
    /* Individual habit card */
    display: flex; /* Flexbox layout */
    align-items: center; /* Vertically center */
    padding: 18px; /* Internal spacing */
    border-radius: 10px; /* Rounded corners */
    background-color: var(--container-bg); /* Use CSS variable */
    border: 1px solid var(--border-color); /* Border */
    transition: transform 0.2s, box-shadow 0.2s; /* Animation on hover */
}

.habit-card:hover {
    /* Hover effect for habit card */
    transform: translateY(-3px); /* Lift up */
    box-shadow: 0 5px 15px rgba(0, 0, 0, 0.1); /* Shadow */
}

.habit-checkbox {
    /* Checkbox for habit completion */
    width: 24px; /* Fixed width */
    height: 24px; /* Fixed height */
    margin-right: 15px; /* Space to the right */
    cursor: pointer; /* Pointer cursor */
    accent-color: var(--success-color); /* Color of checkbox when checked */
}

.habit-info {
    /* Container for habit name and streak */
    flex: 1; /* Take up available space */
}

.habit-name {
    /* Habit name */
    font-size: 1.2rem; /* Medium font */
    font-weight: 600; /* Semi-bold */
    margin-bottom: 5px; /* Space below */
}

.habit-streak {
    /* Container for streak info */
    font-size: 0.95rem; /* Small font */
    color: var(--secondary-color); /* Use CSS variable */
    display: flex; /* Flexbox for icon alignment */
    align-items: center; /* Vertically center */
    gap: 5px; /* Space between icon and text */
}

.habit-streak i {
    /* Fire icon in streak */
    color: var(--danger-color); /* Red color */
}

.progress-container {
    /* Container for progress bar */
    width: 200px; /* Fixed width */
    margin-left: 20px; /* Space from previous element */
}

.progress-label {
    /* Label above progress bar */
    display: flex; /* Flexbox layout */
    justify-content: space-between; /* Space between "Progress" and percentage */
    margin-bottom: 5px; /* Space below */
    font-size: 0.9rem; /* Small font */
}

.progress-bar {
    /* Background of progress bar */
    height: 10px; /* Fixed height */
    background-color: var(--border-color); /* Use CSS variable */
    border-radius: 5px; /* Rounded ends */
    overflow: hidden; /* Hide overflow of fill */
}

.progress-fill {
    /* The filled part of progress bar */
    height: 100%; /* Full height of parent */
    border-radius: 5px; /* Rounded ends */
    transition: width 0.5s ease; /* Smooth width animation */
}

footer {
    /* Footer styles */
    text-align: center; /* Center text */
    padding-top: 20px; /* Space above */
    border-top: 2px solid var(--border-color); /* Top border */
    color: var(--secondary-color); /* Use CSS variable */
    font-size: 0.9rem; /* Small font */
}

.current-day-info {
    /* Current day count in footer */
    margin-top: 10px; /* Space above */
    font-weight: 600; /* Bold */
    color: var(--primary-color); /* Use CSS variable */
}

/* Media queries for responsive design */

@media (max-width: 768px) {
    /* Styles for tablets and smaller screens */
    .header-content {
        flex-direction: column; /* Stack vertically */
        align-items: flex-start; /* Align to left */
    }
    
    .controls {
        width: 100%; /* Full width */
        justify-content: space-between; /* Space buttons evenly */
    }
    
    .section-header {
        flex-direction: column; /* Stack vertically */
        align-items: flex-start; /* Align to left */
    }
    
    .habit-card {
        flex-direction: column; /* Stack vertically */
        align-items: flex-start; /* Align to left */
        gap: 15px; /* Space between stacked elements */
    }
    
    .progress-container {
        width: 100%; /* Full width */
        margin-left: 0; /* Remove left margin */
    }
    
    .calendar-months {
        justify-content: center; /* Center calendar */
    }
}

@media (max-width: 480px) {
    /* Styles for mobile phones */
    .container {
        padding: 15px; /* Less padding */
    }
    
    h1 {
        font-size: 1.8rem; /* Smaller title */
    }
    
    .theme-btn, .next-day-btn {
        padding: 8px 15px; /* Smaller buttons */
        font-size: 0.85rem; /* Smaller font */
    }
    
    .calendar-months {
        gap: 10px; /* Less gap */
    }
    
    .day-cell {
        width: 12px; /* Smaller cells */
        height: 12px; /* Smaller cells */
    }
}
