//Length Conversion
function ConvertToInches(val, sourceUnit) {
    switch (sourceUnit) {
        case "CM":
            return val * 0.3937;
        case "METER":
            return val * 39.37;
        case "FOOT":
            return val * 12;
        default:
            return val;
    }
}

function ConvertToCms(val, sourceUnit) {
    switch (sourceUnit) {
        case "INCH":
            return val * 2.54;
        case "METER":
            return val * 100;
        case "FOOT":
            return val * 30.48;
        default:
            return val;
    }
}

function ConvertToMeters(val, sourceUnit) {
    switch (sourceUnit) {
        case "INCH":
            return val * 0.0254;
        case "CM":
            return val * 0.01;
        case "FOOT":
            return val * 0.3048;
        default:
            return val;
    }
}

function ConvertToFoots(val, sourceUnit) {
    switch (sourceUnit) {
        case "INCH":
            return val * 0.0833;
        case "CM":
            return val * 0.0328;
        case "METER":
            return val * 3.2808;
        default:
            return val;
    }
}

//Weight Conversion

function ConvertToKgs(val, sourceUnit) {
    switch (sourceUnit) {
        case "LBS":
            return val * 0.4535;
        case "GRAM":
            return val * 0.001;
        default:
            return val;
    }
}

function ConvertToLbs(val, sourceUnit) {
    switch (sourceUnit) {
        case "KG":
            return val * 2.2046;
        case "GRAM":
            return val * 0.0022;
        default:
            return val;
    }
}

function ConvertToGrams(val, sourceUnit) {
    switch (sourceUnit) {
        case "KG":
            return val * 1000;
        case "LBS":
            return val * 453.5924;
        default:
            return val;
    }
}